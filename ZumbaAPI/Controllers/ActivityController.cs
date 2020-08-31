using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ZumbaAPI.Repository.Interface;
using ZumbaModels.Models;

namespace ZumbaAPI.Controllers
{
    /// <summary>
    /// Author: Francis Decena 
    /// Date: 31/8/2020
    /// Description: This will handle all the activity request
    /// Calling the IApplicationUserRepository ILogger and IConfiguration
    /// </summary>
    [ApiController]
    public class ActivityController : ControllerBase
    {
        #region Properties
        private readonly IActivityRepository<ActivitiesModel> _activityRepository;
        private readonly ILogger<ActivityController> _logger;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public ActivityController(IActivityRepository<ActivitiesModel> activityRepository, ILogger<ActivityController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _activityRepository = activityRepository;
        }
        #endregion

        /// <summary>
        /// This will call the _activityRepository to get all activities
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("api/Activity/GetActivities")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _activityRepository.GetAll();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in ActivityController||GetAll Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This will call the _activityRepository to get activity by its activityName
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("api/Activity/GetActivity/{activityName}")]
        public async Task<IActionResult> GetActivity(string activityName)
        {
            try
            {
                var result = await _activityRepository.GetActivity(activityName);

                if (result == null)
                {
                    return NotFound($"Can't find activity {activityName}");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in ActivityController||GetActivity Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This will call _activityRepository to create a new Activity
        /// </summary>
        /// <param name="activitiesModel"></param>
        /// <returns></returns>
        [HttpPost, Route("api/Activity")]
        public async Task<IActionResult> CreateActivity(ActivitiesModel activitiesModel)
        {
            try
            {
                var result = await _activityRepository.CreateActivity(activitiesModel);

                //Check if its not 201 response code 
                if (result.Code != 201)
                {
                    return new ContentResult()
                    {
                        Content = Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message,
                        ContentType = "text/plain",
                        StatusCode = result.Code
                    };
                }

                //return Ok(result.Code);
                return new ContentResult()
                {
                    Content = Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = result.Message,
                    ContentType = "text/plain",
                    StatusCode = result.Code
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in ActivityController||CreateActivity Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }
    }
}