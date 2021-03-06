using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.Blogs
{
    public class EditBlog
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Content { get; set; }
            public string BlogType { get; set; }
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
                var blog = await _context.Blogs.FindAsync(request.Id);

                if (blog == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Not found");
                }

                blog.Title = request.Title ?? blog.Title;
                blog.Description = request.Description ?? blog.Description;
                blog.Content = request.Content ?? blog.Content;
                blog.BlogType = request.BlogType ?? blog.BlogType;

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