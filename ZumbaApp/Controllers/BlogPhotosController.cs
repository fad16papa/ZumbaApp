using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ZumbaApp.Models;
using ZumbaApp.Repository.Interfaces;

namespace ZumbaApp.Controllers
{
    public class BlogPhotosController : Controller
    {
        private readonly IBlogsPhotoInterface _blogsPhotoInterface;
        private readonly ILogger<BlogPhotosController> _logger;
        private readonly IConfiguration _configuration;
        public BlogPhotosController(IBlogsPhotoInterface blogsPhotoInterface, ILogger<BlogPhotosController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _blogsPhotoInterface = blogsPhotoInterface;
        }

        [HttpGet]
        public IActionResult UploadBlogPhoto()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in BlogPhotosController||UploadBlogPhoto ErrorMessage: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadBlogPhoto(PhotoModel photoModel, string BlogId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.PhotoUploadError = "Please upload a photo";

                    return View(photoModel);
                }

                var result = await _blogsPhotoInterface.AddBlogPhoto(photoModel.PhotoFile, photoModel.Id, (Request.Cookies[_configuration["ZumbaCookies:ZumbaJwt"]]).ToString());

                if (result.Code != 200)
                {
                    return RedirectToAction("Index", "Error");
                }

                if (HttpContext.Request.Cookies.ContainsKey("BlogReference"))
                    Response.Cookies.Delete(_configuration["ZumbaCookies:BlogAvatar"]);

                Response.Cookies.Append(_configuration["ZumbaCookies:BlogAvatar"], result.Url);

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in BlogPhotosController||UploadBlogPhoto ErrorMessage: {ex.Message}");
                throw;
            }
        }
    }
}