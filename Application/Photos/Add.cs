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

namespace Application.Photos
{
    public class Add
    {
        public class Command : IRequest<Photo>
        {
            public IFormFile File { get; set; }
        }

        public class Handler : IRequestHandler<Command, Photo>
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

            public async Task<Photo> Handle(Command request, CancellationToken cancellationToken)
            {
                var photoUploadResult = _photoAccessor.AddPhoto(request.File);

                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());

                var userPhoto = await _context.Photos.SingleOrDefaultAsync(x => x.UserId == user.Id);

                //if userPhoto exist delete it
                if (userPhoto != null)
                {
                    _context.Remove(userPhoto);

                    var successDelete = await _context.SaveChangesAsync() > 0;

                    if (successDelete)
                    {
                        var photo = new Photo
                        {
                            Url = photoUploadResult.Url,
                            Id = photoUploadResult.PublicId,
                            UserId = user.Id
                        };

                        if (!user.Photos.Any(x => x.IsMain))
                            photo.IsMain = true;

                        user.Photos.Add(photo);

                        var successCreate = await _context.SaveChangesAsync() > 0;

                        if (successCreate) return photo;

                        throw new Exception("Problem saving changes");
                    }
                }
                else
                {
                    var photo = new Photo
                    {
                        Url = photoUploadResult.Url,
                        Id = photoUploadResult.PublicId,
                        UserId = user.Id
                    };

                    if (!user.Photos.Any(x => x.IsMain))
                        photo.IsMain = true;

                    user.Photos.Add(photo);

                    var successCreate = await _context.SaveChangesAsync() > 0;

                    if (successCreate) return photo;

                    throw new Exception("Problem saving changes");
                }

                throw new Exception("Problem saving changes");
            }
        }
    }
}