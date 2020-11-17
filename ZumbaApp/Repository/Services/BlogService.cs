using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Domain;
using Microsoft.Extensions.Logging;
using ZumbaApp.Repository.Interfaces;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Services
{
    public class BlogService : IBlogInterface
    {
        private readonly ILogger<BlogService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public BlogService(ILogger<BlogService> logger, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public Task<ResponseModel> CreateBlog(Blog blog, string token)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Delete(Blog blog, string token)
        {
            throw new NotImplementedException();
        }

        public Task<BlogsEditResponse> EditBlog(BlogsEditResponse model, string token)
        {
            throw new NotImplementedException();
        }

        public Task<Blog> GetBlog(Guid id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Blog>> GetBlogs(string token)
        {
            throw new NotImplementedException();
        }
    }
}