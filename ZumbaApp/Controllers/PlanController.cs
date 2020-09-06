using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ZumbaApp.Controllers
{
    public class PlanController : Controller
    {
        private readonly ILogger<PlanController> _logger;

        public PlanController(ILogger<PlanController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}