using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.Errors;
using AspNetCore.Http.Extensions;
using Castle.Core.Logging;
using Domain;
using Microsoft.AspNetCore.Http;
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

        public async Task<BlogPhotoResponse> AddBlogPhoto(IFormFile formFile, string Id, string token)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                responseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');

                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StreamContent(formFile.OpenReadStream())
                    {
                        Headers =
                    {
                        ContentLength = formFile.Length,
                        ContentType = new MediaTypeHeaderValue(formFile.ContentType)
                    }
                    }, "File", fileName);

                    var result = await responseClient.PostAsync("api/Photos/", content);

                    if (result.StatusCode != HttpStatusCode.OK)
                    {
                        var faliedResponse = await result.Content.ReadAsJsonAsync<RestException>();
                        return new BlogPhotoResponse()
                        {
                            Message = faliedResponse.Errors.ToString(),
                            Code = Convert.ToInt32(result.StatusCode)
                        };
                    }

                    var successResponse = await result.Content.ReadAsJsonAsync<BlogPhoto>();

                    return new BlogPhotoResponse()
                    {
                        Id = successResponse.Id,
                        Url = successResponse.Url,
                        BlogId = successResponse.BlogId,
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in BlogsPhotoService||AddBlogPhoto ErrorMessage: {ex.Message}");
                throw;
            }
        }
    }
}