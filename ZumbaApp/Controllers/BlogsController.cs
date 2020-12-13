using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ZumbaApp.Repository.Interfaces;

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
            var blogs = await _blogInterface.GetBlogs(Request.Cookies[_configuration["ZumbaCookies:ZumbaJwt"]]);

            return View(blogs);
        }
    }
}