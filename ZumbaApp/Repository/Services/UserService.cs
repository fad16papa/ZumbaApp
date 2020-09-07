﻿using AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ZumbaApp.Helper;
using ZumbaApp.Repository.Interfaces;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;
using Application.Errors;

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

                var result = await responseClient.PostAsJsonAsync<LoginModel>("api/User/login", loginModel);

                var user = await result.Content.ReadAsJsonAsync<RestException>();

                return new ResponseModel()
                {
                    Message = user.Errors.ToString(),
                    Code = Convert.ToInt32(result.StatusCode)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in UserService||LoginUser ErrorMessage: {ex.Message}");
                throw ex;
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

                var result = await responseClient.PostAsJsonAsync<RegisterModel>("api/User/register", registerModel);

                var user = await result.Content.ReadAsJsonAsync<RestException>();

                return new ResponseModel()
                {
                    Message = user.Errors.ToString(),
                    Code = Convert.ToInt32(result.StatusCode)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in UserService||RegisterUser ErrorMessage: {ex.Message}");
                throw ex;
            }
        }
    }
}
