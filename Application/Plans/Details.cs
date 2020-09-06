using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Plans
{
    public class Details
    {
        public class Query : IRequest<Plan>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Plan>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Plan> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic goes here
                var plan = await _context.Plans.FindAsync(request.Id);

                if(plan == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Not found" );
                }

                return plan;
            }
        }
    }
}