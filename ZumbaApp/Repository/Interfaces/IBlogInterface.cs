using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Interfaces
{
    public interface IBlogInterface
    {
        Task<object> GetBlogs(string token);
        Task<object> GetBlog(string id, string token);
        Task<BlogResponse> CreateBlog(Blog blog, string token);
        Task<ResponseModel> EditBlog(Guid Id, BlogsEditResponse model, string token);
        Task<ResponseModel> Delete(Guid Id, string token);
    }
}