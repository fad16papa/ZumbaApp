using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ZumbaApp.Repository.Interfaces;
using ZumbaModels.Models;

namespace ZumbaApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;

        public UserController(IUserInterface userInterface, ILogger<UserController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _userInterface = userInterface;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserProfile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            //Delete all cookies from ZumbaApp
            Response.Cookies.Delete(_configuration["ZumbaCookies:ZumbaJwt"]);
            return View("Login");
        }

        [HttpGet]
        public IActionResult UserSetting()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    var result = await _userInterface.LoginUser(loginModel);

                    //check the result 
                    //return the view with the error message from the server side
                    if (result.Code == 401)
                    {
                        _logger.LogError($"Error encountered in UserController||Login Error Message {result.Message}");
                        ViewBag.ErrorMessage = result.Message;
                        return View();
                    }

                    //Save the return JWT to sessionStorage
                    var cookieOptions = new CookieOptions()
                    {
                        Expires = DateTime.Now.AddHours(2),
                        IsEssential = true
                    };

                    Response.Cookies.Append(_configuration["ZumbaCookies:ZumbaJwt"], result.Token, cookieOptions);
                }

                return RedirectToAction("UserProfile", "User");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in UserController||Login ErrorMessage: {ex.Message}");
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPage(RegisterModel registerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    var result = await _userInterface.RegisterUser(registerModel);

                    //check the result 
                    //return the view with the error message from the server side
                    if (result.Code == 409)
                    {
                        _logger.LogError($"Error encountered in UserController||Register Error Message {result.Message}");
                        ViewBag.ErrorMessage = result.Message;

                        return View();
                    }

                    //Save the return JWT to sessionStorage
                    var cookieOptions = new CookieOptions()
                    {
                        Expires = DateTime.Now.AddHours(2),
                        IsEssential = true
                    };

                    Response.Cookies.Append(_configuration["ZumbaCookies:ZumbaJwt"], result.Token, cookieOptions);
                }

                return RedirectToAction("Index", "Plan");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in UserController||RegisterPage ErrorMessage: {ex.Message}");
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
