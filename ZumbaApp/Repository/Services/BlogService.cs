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

                var result = await responseClient.PostAsJsonAsync<Blog>("api/Blogs/", blog);

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
                throw;
            }
        }

        public async Task<ResponseModel> Delete(Guid Id, string token)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                responseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await responseClient.DeleteAsync("api/Blogs/" + Id);

                result.Content.ReadAsStringAsync().ToString();

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    var faliedResponse = await result.Content.ReadAsJsonAsync<RestException>();
                    return new ResponseModel()
                    {
                        Message = faliedResponse.Errors.ToString(),
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                return new ResponseModel()
                {
                    Code = Convert.ToInt32(result.StatusCode)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in BlogService||Delete ErrorMessage: {ex.Message}");
                throw;
            }
        }

        public async Task<ResponseModel> EditBlog(Guid Id, BlogsEditResponse model, string token)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                responseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await responseClient.PutAsJsonAsync<BlogsEditResponse>("api/Blogs/" + Id, model);

                result.Content.ReadAsStringAsync().ToString();

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    var faliedResponse = await result.Content.ReadAsJsonAsync<RestException>();
                    return new ResponseModel()
                    {
                        Message = faliedResponse.Errors.ToString(),
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                return new ResponseModel()
                {
                    Code = Convert.ToInt32(result.StatusCode)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in BlogService||EditBlog ErrorMessage: {ex.Message}");
                throw;
            }
        }

        public async Task<object> GetBlog(Guid id, string token)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                responseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await responseClient.GetAsync("api/Blogs/" + id);

                result.Content.ReadAsStringAsync().ToString();

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    var faliedResponse = await result.Content.ReadAsJsonAsync<RestException>();
                    return new ResponseModel()
                    {
                        Message = faliedResponse.Errors.ToString(),
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                var blog = await result.Content.ReadAsJsonAsync<Blog>();

                return blog;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in BlogService||GetBlog ErrorMessage: {ex.Message}");
                throw;
            }
        }

        public async Task<object> GetBlogs(string token)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                responseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await responseClient.GetAsync("api/Blogs/");

                result.Content.ReadAsStringAsync().ToString();

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    var faliedResponse = await result.Content.ReadAsJsonAsync<RestException>();
                    return new ResponseModel()
                    {
                        Message = faliedResponse.Errors.ToString(),
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                var blogs = await result.Content.ReadAsJsonAsync<List<BlogResponse>>();

                return blogs;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in BlogService||GetBlogs ErrorMessage: {ex.Message}");
                throw;
            }
        }
    }
}