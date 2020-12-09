using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.Errors;
using AspNetCore.Http.Extensions;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using ZumbaApp.Repository.Interfaces;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Services
{
    public class BlogsPhotoService : IBlogsPhotoInterface
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BlogsPhotoService> _logger;
        public BlogsPhotoService(ILogger<BlogsPhotoService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<object> AddBlogPhoto(string token, Guid Id)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                responseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await responseClient.DeleteAsync("api/BlogsPhoto/" + Id);

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
                _logger.LogError($"Error encountered in BlogsPhotoService||AddBlogPhoto ErrorMessage: {ex.Message}");
                throw;
            }
        }
    }
}