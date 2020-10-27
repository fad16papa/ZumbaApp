using AspNetCore.Http.Extensions;
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
using System.Net;
using Application.User;
using Domain;
using System.Net.Http.Headers;

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

        public async Task<UserResponseModel> GetCurrentUser(string token)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                responseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await responseClient.GetAsync("api/User/");

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    var faliedResponse = await result.Content.ReadAsJsonAsync<RestException>();
                    return new UserResponseModel()
                    {
                        Message = faliedResponse.Errors.ToString(),
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                var successResponse = await result.Content.ReadAsJsonAsync<UserResponseModel>();

                return new UserResponseModel()
                {
                    DisplayName = successResponse.DisplayName,
                    UserName = successResponse.UserName,
                    Code = Convert.ToInt32(result.StatusCode)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in UserService||GetCurrentUser ErrorMessage: {ex.Message}");
                throw;
            }
        }

        public async Task<UserDetailsResponseModel> GetUserDetails(string userName, string token)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                responseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await responseClient.GetAsync("api/User/" + userName);

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    var faliedResponse = await result.Content.ReadAsJsonAsync<RestException>();
                    return new UserDetailsResponseModel()
                    {
                        Message = faliedResponse.Errors.ToString(),
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                var successResponse = await result.Content.ReadAsJsonAsync<AppUser>();

                return new UserDetailsResponseModel()
                {
                    UserName = successResponse.UserName,
                    FirstName = successResponse.FirstName,
                    LastName = successResponse.LastName,
                    Email = successResponse.Email,
                    BirthDate = successResponse.BirthDate,
                    Country = successResponse.Country,
                    City = successResponse.City,
                    DisplayName = successResponse.DisplayName
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in UserService||GetUserDetails ErrorMessage: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// This service will handle the login 
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<LoginResponseModel> LoginUser(LoginModel loginModel)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                var result = await responseClient.PostAsJsonAsync<LoginModel>("api/User/login", loginModel);

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    var faliedResponse = await result.Content.ReadAsJsonAsync<RestException>();
                    return new LoginResponseModel()
                    {
                        Message = faliedResponse.Errors.ToString(),
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                var successResponse = await result.Content.ReadAsJsonAsync<User>();
                return new LoginResponseModel()
                {
                    DisplayName = successResponse.DisplayName,
                    UserName = successResponse.UserName,
                    Token = successResponse.Token,
                    Image = successResponse.Image,
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
        public async Task<LoginResponseModel> RegisterUser(RegisterModel registerModel)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                var result = await responseClient.PostAsJsonAsync<RegisterModel>("api/User/register", registerModel);

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    var faliedResponse = await result.Content.ReadAsJsonAsync<RestException>();
                    return new LoginResponseModel()
                    {
                        Message = faliedResponse.Errors.ToString(),
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                var successResponse = await result.Content.ReadAsJsonAsync<User>();
                return new LoginResponseModel()
                {
                    DisplayName = successResponse.DisplayName,
                    UserName = successResponse.UserName,
                    Token = successResponse.Token,
                    Image = successResponse.Image,
                    Code = Convert.ToInt32(result.StatusCode)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in UserService||RegisterUser ErrorMessage: {ex.Message}");
                throw ex;
            }
        }

        public async Task<UserDetailsResponseModel> UpdateUserDetails(UserDetailsResponseModel model, string token)
        {
            try
            {
                var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

                responseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var result = await responseClient.PostAsJsonAsync<UserDetailsResponseModel>("api/User", model);

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    var faliedResponse = await result.Content.ReadAsJsonAsync<RestException>();
                    return new UserDetailsResponseModel()
                    {
                        Message = faliedResponse.Errors.ToString(),
                        Code = Convert.ToInt32(result.StatusCode)
                    };
                }

                model.Code = Convert.ToInt32(result.StatusCode);

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in UserService||UpdateUserDetails ErrorMessage: {ex.Message}");
                throw ex;
            }
        }
    }
}
