using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ZumbaApp.Repository.Interfaces;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ILogger<BlogsController> _logger;
        private readonly IBlogInterface _blogInterface;
        private readonly IConfiguration _configuration;
        public BlogsController(ILogger<BlogsController> logger, IBlogInterface blogInterface, IConfiguration configuration)
        {
            _configuration = configuration;
            _blogInterface = blogInterface;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var blogs = await _blogInterface.GetBlogs(Request.Cookies[_configuration["ZumbaCookies:ZumbaJwt"]]);

                return View(blogs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in BlogsController||CreateBlog ErrorMessage: {ex.Message}");
                throw;
            }
        }

        [HttpGet]
        public IActionResult CreateBlog()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in BlogsController||CreateBlog ErrorMessage: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogResponse blogResponse)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var blog = new Blog()
                {
                    Title = blogResponse.Title,
                    Description = blogResponse.Description,
                    BlogType = blogResponse.BlogType,
                    Content = blogResponse.Content,
                    DateCreated = DateTime.Now
                };

                var result = await _blogInterface.CreateBlog(blog, (Request.Cookies[_configuration["ZumbaCookies:ZumbaJwt"]]).ToString());

                if (result.Code != 200)
                {
                    return RedirectToAction("Index", "Error");
                }

                return RedirectToAction("Index", "Blogs");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in BlogsController||CreateBlog ErrorMessage: {ex.Message}");
                throw;
            }
        }
    }
}