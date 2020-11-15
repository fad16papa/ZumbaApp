using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Blogs
{
    public class DetailsBlog
    {
        public class Query : IRequest<Blog>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Blog>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Blog> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic goes here
                var blog = await _context.Blogs.FindAsync(request.Id);

                if (blog == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Not found");
                }

                return blog;
            }
        }
    }
}