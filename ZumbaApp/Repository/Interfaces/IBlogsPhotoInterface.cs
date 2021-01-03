using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Interfaces
{
    public interface IBlogsPhotoInterface
    {
        Task<BlogPhotoResponse> AddBlogPhoto(IFormFile formFile, string Id, string token);
    }
}