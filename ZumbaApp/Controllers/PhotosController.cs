using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ZumbaApp.Models;
using ZumbaApp.Repository.Interfaces;

namespace ZumbaApp.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ILogger<PhotosController> _logger;
        private readonly IPhotoInterface _photoInterface;
        private readonly IConfiguration _configuration;
        public PhotosController(IPhotoInterface photoInterface, ILogger<PhotosController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _photoInterface = photoInterface;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult UplaodUserPhoto()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PhotosController||UplaodUserPhoto ErrorMessage: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UplaodUserPhoto(PhotoModel photoModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.PhotoUploadError = "Please upload a photo";

                    return View(photoModel);
                }

                var result = await _photoInterface.AddUserPhoto(photoModel.PhotoFile, (Request.Cookies[_configuration["ZumbaCookies:ZumbaJwt"]]).ToString());

                if (result.Code != 200)
                {
                    return RedirectToAction("Index", "Error");
                }

                if (HttpContext.Request.Cookies.ContainsKey("AvatarReference"))
                    Response.Cookies.Delete(_configuration["ZumbaCookies:UserAvatar"]);

                Response.Cookies.Append(_configuration["ZumbaCookies:UserAvatar"], result.Url);

                return RedirectToAction("UserSetting", "User");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PhotosController||UplaodUserPhoto ErrorMessage: {ex.Message}");
                throw;
            }
        }
    }
}