using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using ZumbaApp.Repository.Interfaces;
using ZumbaModels.Models;

namespace ZumbaApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserInterface userInterface, ILogger<UserController> logger)
        {
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
                    if (result.Code != 200)
                    {
                        _logger.LogError($"Error encountered in UserController||Login Error Message {result.Message}");
                        ViewBag.ErrorMessage = result.Message;
                        return View();
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                throw ex;
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
                    if (result.Code != 201)
                    {
                        _logger.LogError($"Error encountered in UserController||Register Error Message {result.Message}");
                        ViewBag.ErrorMessage = result.Message;
                        return View();
                    }
                }

                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
