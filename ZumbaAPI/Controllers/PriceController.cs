using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Date: 01/09/2020
    /// Description: This will hanlde all the price request 
    /// Calling the IPricingRepository ILogger IConfiguration
    /// </summary>
    [ApiController]
    public class PriceController : ControllerBase
    {
        #region Properties
        private readonly IPricingRepository<PricingModel> _pricingRepository;
        private readonly ILogger<PriceController> _logger;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public PriceController(IPricingRepository<PricingModel> pricingRepository, ILogger<PriceController> logger, IConfiguration configuration)
        {
            _pricingRepository = pricingRepository;
            _logger = logger;
            _configuration = configuration;
        }
        #endregion

        /// <summary>
        /// This will call _pricingRepository to gett all prices.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("api/Price/GetPrices")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _pricingRepository.GetAll();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PriceController||GetAll Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This will call _pricingRepository to get price by its priceName
        /// </summary>
        /// <param name="priceName"></param>
        /// <returns></returns>
        [HttpGet, Route("api/Price/GetPrice/{priceName}")]
        public async Task<IActionResult> GetPrice(string priceName)
        {
            try
            {
                var result = await _pricingRepository.GetPrice(priceName);

                if (result == null)
                {
                    return NotFound($"Can't find price {priceName}");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PriceController||GetPrice Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This will call _pricingRepository to create a new price
        /// </summary>
        /// <param name="pricingModel"></param>
        /// <returns></returns>
        [HttpPost, Route("api/Price")]
        public async Task<IActionResult> CreatePrice([FromBody] PricingModel pricingModel)
        {
            try
            {
                var result = await _pricingRepository.CreatePrice(pricingModel);

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
                _logger.LogError($"Error encountered in PriceController||CreatePrice Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This will call _pricingRepository to update a price
        /// </summary>
        /// <param name="pricingModel"></param>
        /// <returns></returns>
        [HttpPut, Route("api/Price")]
        public async Task<IActionResult> UpdatePrice([FromBody] PricingModel pricingModel)
        {
            try
            {
                var result = await _pricingRepository.UpdatePrice(pricingModel);

                //Check if its not 200 response code 
                if (result.Code != 200)
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
                _logger.LogError($"Error encountered in PriceController||UpdatePrice Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This will call _pricingRepository to delete a price
        /// </summary>
        /// <param name="priceName"></param>
        /// <returns></returns>
        [HttpDelete, Route("api/Price/{priceName}")]
        public async Task<IActionResult> DeletePrice(string priceName)
        {
            try
            {
                var result = await _pricingRepository.DeletePrice(priceName);

                //Check if its not 200 response code 
                if (result.Code != 200)
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
                _logger.LogError($"Error encountered in PriceController||DeletePrice Message:{ex.Message}.");
                return BadRequest(ex.Message);
            }
        }
    }
}
