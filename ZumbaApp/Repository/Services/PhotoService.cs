using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.Errors;
using AspNetCore.Http.Extensions;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ZumbaApp.Repository.Interfaces;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Services
{
    public class PhotoService : IPhotoInterface
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PhotoService> _logger;
        public PhotoService(ILogger<PhotoService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserPhotoResponse> AddUserPhoto(IFormFile formFile, string token)
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
                        return new UserPhotoResponse()
                        {
                            Message = faliedResponse.Errors.ToString(),
                            Code = Convert.ToInt32(result.StatusCode)
                        };
                    }

                    var successResponse = await result.Content.ReadAsJsonAsync<Photo>();

                    return new UserPhotoResponse()
                    {
                        Id = successResponse.Id,
                        Url = successResponse.Url,
                        UserId = successResponse.UserId,
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PhotoService||AddUserPhoto ErrorMessage: {ex.Message}");
                throw;
            }
        }
    }
}