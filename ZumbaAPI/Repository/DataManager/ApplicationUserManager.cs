using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZumbaAPI.DBContext;
using ZumbaAPI.Repository.Interface;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;
using ZumbaModels.Models.User;

namespace ZumbaAPI.Repository.DataManager
{
    /// <summary>
    /// Author: Francis Decena
    /// Date: 30/08/2020
    /// Description: This will hanlde the data factory for ApplicationUser
    /// </summary>
    public class ApplicationUserManager : IApplicationUserRepository<ApplicationUser>
    {
        #region Properties
        private readonly ZumbaDbContext _zumbaDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IUserAccessorRepository _userAccessorRepository;
        private readonly ILogger<ApplicationUserManager> _logger;
        #endregion

        #region Constructor
        public ApplicationUserManager(ZumbaDbContext zumbaDbContext, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IUserAccessorRepository userAccessorRepository, ILogger<ApplicationUserManager> logger)
        {
            _zumbaDbContext = zumbaDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _userAccessorRepository = userAccessorRepository;
            _logger = logger;
        }
        #endregion

        /// <summary>
        /// This will authenticate the user
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> AuthenticateUser(LoginModel loginModel)
        {
            try
            {
                //check if the email of the user is correct
                var checkEmail = await _userManager.FindByEmailAsync(loginModel.Email);

                if(checkEmail == null)
                {
                    return new ResponseModel()
                    {
                        Message = string.Format($"Invalid Credentials for user {loginModel.Email}."),
                        Code = 400
                    };
                }

                //check if the password is correct 
                var validPassword = await _userManager.CheckPasswordAsync(checkEmail, loginModel.Password);

                if(!validPassword)
                {
                    return new ResponseModel()
                    {
                        Message = string.Format($"Invalid Credentials for user {loginModel.Email}."),
                        Code = 400
                    };
                }

                //user successfully login
                _logger.LogInformation($"User {loginModel.Email} successfully login.");

                return new ResponseModel()
                {
                    Message = string.Format($"User {loginModel.Email} successfully login."),
                    Code = 200
                };

            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                   Message = string.Format($"Error encountered in ApplicationUserManager||AuthenticateUser Message:{ex.Message}"),
                   Code = 500
                };
            }
        }

        /// <summary>
        /// Get all the users 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            try
            {
                return await _userManager.Users.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get user by its username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetUser(string userName)
        {
            try
            {
                return await _userManager.FindByNameAsync(userName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// This will create a new user 
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> RegisterUser(RegisterModel registerModel)
        {
            try
            {
                //Check if the user is already used 
                var user = await _userManager.FindByNameAsync(registerModel.UserName);

                if(user != null)
                {
                    return new ResponseModel()
                    {
                        Message = "UserName Already exist",
                        Code = 900
                    };
                }

                //Check if the email is already used
                var email = await _userManager.FindByEmailAsync(registerModel.Email);

                if(email != null)
                {
                    return new ResponseModel()
                    {
                        Message = "Email Already exist",
                        Code = 901
                    };
                }

                //Create a new ApplicationUser object
                var applicationUser = new ApplicationUser()
                {
                    UserName = registerModel.UserName, 
                    Email = registerModel.Email,
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName, 
                    JoinDate = DateTime.Now,
                    EmailConfirmed = true, 
                };

                //Insert ApplicationUser object in IdetityCore 
                var result = await _userManager.CreateAsync(applicationUser, registerModel.Password);

                if(!result.Succeeded)
                {
                    return new ResponseModel()
                    {
                        Message = "User not successfully created",
                        Code = 500
                    };
                }

                return new ResponseModel()
                {
                   Message = "User successfully created",
                   Code = 201
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = string.Format($"Error encountered in ApplicationUserManager||RegisterUser Message:{ex.Message}"),
                    Code = 500
                };
            }
        }

        /// <summary>
        /// This will update userProfile
        /// </summary>
        /// <param name="claimsPrincipal"></param>
        /// <param name="updateUserProfile"></param>
        /// <returns></returns>
        public async Task<ResponseModel> UpdateUser(ClaimsPrincipal claimsPrincipal, UpdateUserProfile updateUserProfile)
        {
            try
            {
                //get the current user via claimsPrincipal
                var user = await _userManager.GetUserAsync(claimsPrincipal);

                if(user == null)
                {
                    return new ResponseModel()
                    {
                        Message = string.Format($"User not found"),
                        Code = 400
                    };
                }

                //check the object updateUserProfile if the properties is not null change the value 
                //if not retain the same old of the properties
                if(updateUserProfile.FirstName != null)
                {
                    user.FirstName = updateUserProfile.FirstName;
                }
                if(updateUserProfile.LastName != null)
                {
                    user.LastName = updateUserProfile.LastName;
                }
                if(updateUserProfile.Email != null)
                {
                    user.Email = updateUserProfile.Email;
                }

                //save the updated profile 
                var result = await _userManager.UpdateAsync(user);

                if(!result.Succeeded)
                {
                    return new ResponseModel()
                    {
                        Message = string.Format($"Not successfully update user profile"),
                        Code = 400
                    };
                }

                return new ResponseModel()
                {
                    Message = string.Format($"Successfully update user profile"),
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = string.Format($"Error encountered in ApplicationUserManager||UpdateUser Message:{ex.Message}"),
                    Code = 500
                };
            }
        }
    }
}
