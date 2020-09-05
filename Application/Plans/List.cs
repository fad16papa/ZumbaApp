using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Plans
{
    public class List
    {
        public class Query : IRequest<List<Plan>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Plan>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Plan>> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic goes here
                var plans = await _context.Plans.ToListAsync();

                return plans;
            }
        }
    }
}