using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Blogs
{
    public class List
    {
        public class Query : IRequest<List<Blog>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Blog>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Blog>> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic goes here
                var blogs = await _context.Blogs.ToListAsync();

                return blogs;
            }
        }
    }
}