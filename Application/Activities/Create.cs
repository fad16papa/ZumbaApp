using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
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

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ActivityName).NotEmpty();
                RuleFor(x => x.ActivityDescription).NotEmpty();
                RuleFor(x => x.ActivityLink).NotEmpty();
                RuleFor(x => x.ActivityVenue).NotEmpty();
                RuleFor(x => x.IsActive).NotEmpty();
                RuleFor(x => x.DateCreated).NotEmpty();
            }
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
                var activity = new Activity
                {
                    Id = request.Id,
                    ActivityName = request.ActivityName,
                    ActivityDescription = request.ActivityDescription,
                    ActivityLink = request.ActivityLink,
                    ActivityVenue = request.ActivityVenue,
                    IsActive = request.IsActive,
                    DateCreated = request.DateCreated
                };

                _context.Activities.Add(activity);

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