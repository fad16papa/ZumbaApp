using System;
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
            //TODO: Get all the plan list from API 
            try
            {
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PlanController||Index ErrorMessage: {ex.Message}");
                return RedirectToAction("Index", "Error");
            }

            return View();
        }
    }
}