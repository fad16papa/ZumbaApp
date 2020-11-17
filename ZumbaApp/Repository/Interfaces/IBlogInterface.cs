using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Interfaces
{
    public interface IBlogInterface
    {
        Task<IEnumerable<Blog>> GetBlogs(string token);
        Task<Blog> GetBlog(Guid id, string token);
        Task<ResponseModel> CreateBlog(Blog blog, string token);

    }
}