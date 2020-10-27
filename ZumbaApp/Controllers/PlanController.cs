using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ZumbaApp.Repository.Interfaces;

namespace ZumbaApp.Controllers
{
    public class PlanController : Controller
    {
        private readonly ILogger<PlanController> _logger;
        private readonly IPlanInterface _planInterface;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlanController(ILogger<PlanController> logger, IPlanInterface planInterface, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _planInterface = planInterface;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //TODO: Get all the plan list from API 
            try
            {
                string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["ZumbaReference"];
                var result = await _planInterface.GetAll(cookieValueFromContext);

                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PlanController||Index ErrorMessage: {ex.Message}");
                return RedirectToAction("Index", "Error");
            }
        }
    }
}