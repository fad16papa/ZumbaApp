using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZumbaApp.Repository.Interfaces;

namespace ZumbaApp.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ILogger<BlogsController> _logger;
        private readonly IBlogInterface _blogInterface;
        public BlogsController(ILogger<BlogsController> logger, IBlogInterface blogInterface)
        {
            _blogInterface = blogInterface;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}