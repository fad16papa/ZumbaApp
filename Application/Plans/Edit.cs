using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.Plans
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string PlanName { get; set; }
            public string PlanDescription { get; set; }
            public bool UnlimitedSession { get; set; }
            public bool VIPAccess { get; set; }
            public bool Mentorship { get; set; }
            public bool Billing { get; set; }
            public bool Invoicing { get; set; }
            public string Price { get; set; }
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
                //logic goes here
                var plan = await _context.Plans.FindAsync(request.Id);

                if (plan == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Not found");
                }

                plan.PlanName = request.PlanName ?? plan.PlanName;
                plan.PlanDescription = request.PlanDescription ?? plan.PlanDescription;
                plan.UnlimitedSession = request.UnlimitedSession;
                plan.VIPAccess = request.VIPAccess;
                plan.Mentorship = request.Mentorship;
                plan.Billing = request.Billing;
                plan.Invoicing = request.Invoicing;
                plan.Price = request.Price;
                plan.IsActive = request.IsActive;

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
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