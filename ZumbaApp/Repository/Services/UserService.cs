using AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ZumbaApp.Repository.Interfaces;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Services
{
    /// <summary>
    /// Author: Francis Decena
    /// Date: 30/8/2020
    /// Description: This will handle all Api request from client to API and get the response from the server.
    /// </summary>
    public class UserService : IUserInterface
    {
        private readonly ILogger<UserService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public UserService(ILogger<UserService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// This service will handle the login 
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> LoginUser(LoginModel loginModel)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                var result = await responseClient.PostAsJsonAsync<LoginModel>("api/User/Authenticate", loginModel);

                if(!result.IsSuccessStatusCode)
                {
                    return new ResponseModel()
                    {
                        Message = result.ReasonPhrase,
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                return new ResponseModel()
                {
                    Message = result.ReasonPhrase,
                    Code = Convert.ToInt32(result.StatusCode)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in UserService||LoginUser ErrorMessage: {ex.Message}");
                return new ResponseModel()
                {
                    Message = string.Format($"Error encountered in UserService||LoginUser ErrorMessage: {ex.Message}"),
                    Code = 500
                };
            }
        }

        /// <summary>
        /// This service will handle the register
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> RegisterUser(RegisterModel registerModel)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                var result = await responseClient.PostAsJsonAsync<RegisterModel>("api/ApplicationUser/Register", registerModel);

                if (!result.IsSuccessStatusCode)
                {
                    return new ResponseModel()
                    {
                        Message = result.ReasonPhrase,
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                return new ResponseModel()
                {
                    Message = result.ReasonPhrase,
                    Code = Convert.ToInt32(result.StatusCode)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in UserService||RegisterUser ErrorMessage: {ex.Message}");
                return new ResponseModel()
                {
                    Message = string.Format($"Error encountered in UserService||RegisterUser ErrorMessage: {ex.Message}"),
                    Code = 500
                };
            }
        }
    }
}
