using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BlogsPhoto
{
    public class AddBlogPhoto
    {
        public class Command : IRequest<BlogPhoto>
        {
            public Guid Id { get; set; }
            public IFormFile File { get; set; }
        }

        public class Handler : IRequestHandler<Command, BlogPhoto>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IPhotoAccessor _photoAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor, IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<BlogPhoto> Handle(Command request, CancellationToken cancellationToken)
            {
                var photoUploadResult = _photoAccessor.AddPhoto(request.File);

                var user = await _context.Blogs.SingleOrDefaultAsync(x => x.Id == request.Id);

                var blogPhoto = new BlogPhoto
                {
                    Url = photoUploadResult.Url,
                    Id = photoUploadResult.PublicId
                };

                if (!user.BlogPhotos.Any(x => x.IsMain))
                    blogPhoto.IsMain = true;

                user.BlogPhotos.Add(blogPhoto);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return blogPhoto;

                throw new Exception("Problem saving changes");
            }
        }
    }
}