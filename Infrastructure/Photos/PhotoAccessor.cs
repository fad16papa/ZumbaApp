
using System;
using Application.Interfaces;
using Application.Photos;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Photos
{
    public class PhotoAccessor : IPhotoAccessor
    {
        private readonly Cloudinary _cloudinary;
        public PhotoAccessor(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.Secrets
            );

            _cloudinary = new Cloudinary(acc);
        }

        public PhotoUploadResult AddPhoto(IFormFile file)
        {
            var uploadResults = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream)
                    };

                    uploadResults = _cloudinary.Upload(uploadParams);
                }
            }

            if (uploadResults.Error != null)
                throw new Exception(uploadResults.Error.Message);

            return new PhotoUploadResult
            {
                PublicId = uploadResults.PublicId,
                Url = uploadResults.SecureUrl.AbsoluteUri
            };
        }

        public string DeletePhoto(string publicId)
        {
            throw new System.NotImplementedException();
        }
    }
}