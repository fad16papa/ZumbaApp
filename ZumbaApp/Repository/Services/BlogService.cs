using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.Errors;
using AspNetCore.Http.Extensions;
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

        public async Task<BlogResponse> CreateBlog(Blog blog, string token)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                responseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await responseClient.PostAsJsonAsync<Blog>("api/User/", blog);

                result.Content.ReadAsStringAsync().ToString();

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    var faliedResponse = await result.Content.ReadAsJsonAsync<RestException>();
                    return new BlogResponse()
                    {
                        Message = faliedResponse.Errors.ToString(),
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                var successResponse = await result.Content.ReadAsJsonAsync<Blog>();
                return new BlogResponse()
                {
                    Title = successResponse.Title,
                    Description = successResponse.Description,
                    Content = successResponse.Content,
                    DateCreated = successResponse.DateCreated,
                    Code = Convert.ToInt32(result.StatusCode)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in BlogService||CreateBlog ErrorMessage: {ex.Message}");
                throw ex;
            }
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