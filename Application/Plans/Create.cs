using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Plans
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string PlanName { get; set; }
            public string PlanDescription { get; set; }
            public string Price { get; set; }
            public bool IsActive { get; set; }
            public DateTime DateCreated { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.PlanName).NotEmpty();
                RuleFor(x => x.PlanDescription).NotEmpty();
                RuleFor(x => x.Price).NotEmpty();
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
                //logic goes here
                var plan = new Plan()
                {
                    Id = request.Id,
                    PlanName = request.PlanName,
                    PlanDescription = request.PlanDescription,
                    Price = request.Price,
                    IsActive = request.IsActive,
                    DateCreated = request.DateCreated
                };

                _context.Plans.Add(plan);

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