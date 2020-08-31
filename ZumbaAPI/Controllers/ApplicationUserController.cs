using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ZumbaAPI.Repository.Interface;
using ZumbaModels.Models;
using ZumbaModels.Models.User;

namespace ZumbaAPI.Controllers
{
    /// <summary>
    /// Author: Francis Decena 
    /// Date: 29/8/2020
    /// Description: This will handle all the user request 
    /// Calling the IApplicationUserRepository ILogger and IConfiguration
    /// </summary>
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        #region Properties
        private readonly IApplicationUserRepository<ApplicationUser> _applicationUserRepository;
        private readonly ILogger<ApplicationUserController> _logger;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public ApplicationUserController(IApplicationUserRepository<ApplicationUser> applicationUserRepository, ILogger<ApplicationUserController> logger, IConfiguration configuration)
        {
            _applicationUserRepository = applicationUserRepository;
            _logger = logger;
            _configuration = configuration;
        }
        #endregion

        /// <summary>
        /// This will call the _applicationUserRepository to get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("api/User/GetUsers")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var result = await _applicationUserRepository.GetAll();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in ApplicationUserController||GetAllUser Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This will call the _applicationUserRepository to get the user by its userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet, Route("api/User/GetUser/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            try
            {
                var result = await _applicationUserRepository.GetUser(userName);

                if (result == null)
                {
                    return BadRequest($"Can't find user with the username {userName}");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in ApplicationUserController||GetUserByUserName Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This will call the _applicationUserRepository to create a new user
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        [HttpPost, Route("api/ApplicationUser/Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            try
            {
                var result = await _applicationUserRepository.RegisterUser(registerModel);

                //Check if 201 response code 
                if(result.Code != 201)
                {
                    return new ContentResult()
                    {
                        Content = Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message,
                        ContentType = "text/plain",
                        StatusCode = result.Code
                    };
                }

                //return Ok(result.Code);
                 return new ContentResult()
                {
                     Content = Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message,
                     ContentType = "text/plain",
                     StatusCode = result.Code
                 };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in ApplicationUserController||Register Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This will call _applicationUserRepository to authenticate the user
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost, Route("api/User/Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel loginModel)
        {
            try
            {
                var result = await _applicationUserRepository.AuthenticateUser(loginModel);

                if(result.Code != 200)
                {
                    return new ContentResult()
                    {
                        Content = Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message,
                        ContentType = "text/plain",
                        StatusCode = result.Code
                    };
                }

                return new ContentResult()
                {
                    Content = Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message,
                    ContentType = "text/plain",
                    StatusCode = result.Code
                };

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in ApplicationUserController||Authenticate Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This will call _applicationUserRepository to update userProfile
        /// </summary>
        /// <param name="updateUserProfile"></param>
        /// <returns></returns>
        [HttpPut, Route("api/User/UpdateUser")]
        public async Task<IActionResult> UpdateUserProile([FromBody] UpdateUserProfile updateUserProfile)
        {
            try
            {
                var result = await _applicationUserRepository.UpdateUser(HttpContext.User, updateUserProfile);

                if(result.Code != 200)
                {
                    return new ContentResult()
                    {
                        Content = Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message,
                        ContentType = "text/plain",
                        StatusCode = result.Code
                    };
                }

                return new ContentResult()
                {
                    Content = Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message,
                    ContentType = "text/plain",
                    StatusCode = result.Code
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in ApplicationUserController||UpdateUserProile Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }
    }
}
