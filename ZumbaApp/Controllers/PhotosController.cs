using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZumbaApp.Repository.Interfaces;

namespace ZumbaApp.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ILogger<PhotosController> _logger;
        private readonly IPhotoInterface _photoInterface;
        public PhotosController(IPhotoInterface photoInterface, ILogger<PhotosController> logger)
        {
            _photoInterface = photoInterface;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult UplaodUserPhoto(IFormFile formFile)
        {
            try
            {
                if (formFile.Length <= 0)
                {
                    ViewBag.PhotoUploadError = "Please upload a photo";

                    return RedirectToAction("User", "UserSetting");
                }

                return RedirectToAction("User", "UserSetting");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PhotosController||UplaodUserPhoto ErrorMessage: {ex.Message}");
                throw ex;
            }
        }
    }
}