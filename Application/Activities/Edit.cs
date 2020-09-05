using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string ActivityName { get; set; }
            public string ActivityDescription { get; set; }  
            public string ActivityLink { get; set; }
            public string ActivityVenue { get; set; }
            public bool IsActive { get; set; }
            public DateTime DateCreated { get; set; }
        }
        
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id);

                if(activity == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Activity = "Not found" });
                }

                activity.ActivityName = request.ActivityName ?? activity.ActivityName;
                activity.ActivityDescription = request.ActivityDescription ?? activity.ActivityDescription;
                activity.ActivityLink = request.ActivityLink ?? activity.ActivityLink;
                activity.ActivityVenue = request.ActivityVenue ?? activity.ActivityVenue;
                activity.IsActive = request.IsActive;
                
                var success = await _context.SaveChangesAsync() > 0;

                if(success)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Problem saving changes");
                }
            }
        }
    }
}