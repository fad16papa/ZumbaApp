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

                var blog = await _context.Blogs.SingleOrDefaultAsync(x => x.Id == request.Id);

                var blogPhoto = await _context.BlogPhotos.SingleOrDefaultAsync(x => x.BlogId == blog.Id.ToString());

                //if blogPhoto exist delete it
                if (blogPhoto != null)
                {
                    _context.Remove(blogPhoto);

                    var successDelete = await _context.SaveChangesAsync() > 0;

                    if (successDelete)
                    {
                        var photo = new BlogPhoto
                        {
                            Url = photoUploadResult.Url,
                            Id = photoUploadResult.PublicId,
                            BlogId = blog.Id.ToString()
                        };

                        if (!blog.BlogPhotos.Any(x => x.IsMain))
                            photo.IsMain = true;

                        blog.BlogPhotos.Add(photo);

                        var successCreate = await _context.SaveChangesAsync() > 0;

                        if (successCreate) return photo;

                        throw new Exception("Problem saving changes");
                    }
                }
                else
                {
                    var photo = new BlogPhoto
                    {
                        Url = photoUploadResult.Url,
                        Id = photoUploadResult.PublicId,
                        BlogId = blog.Id.ToString()
                    };

                    if (!blog.BlogPhotos.Any(x => x.IsMain))
                        photo.IsMain = true;

                    blog.BlogPhotos.Add(photo);

                    var successCreate = await _context.SaveChangesAsync() > 0;

                    if (successCreate) return photo;

                    throw new Exception("Problem saving changes");
                }

                throw new Exception("Problem saving changes");
            }
        }
    }
}