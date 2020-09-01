using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZumbaAPI.DBContext;
using ZumbaAPI.Repository.Interface;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaAPI.Repository.DataManager
{
    /// <summary>
    /// Author: Francis Decena
    /// Date: 30/08/2020
    /// Description: This will handle the data factory for PricingModel
    /// </summary>
    public class PricingManager : IPricingRepository<PricingModel>
    {
        #region Properties
        private readonly ILogger<PricingManager> _logger;
        private readonly ZumbaDbContext _zumbaDbContext;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public PricingManager(ILogger<PricingManager> logger, ZumbaDbContext zumbaDbContext, IConfiguration configuration)
        {
            _logger = logger;
            _zumbaDbContext = zumbaDbContext;
            _configuration = configuration;
        }
        #endregion

        /// <summary>
        /// This will create a new Price
        /// </summary>
        /// <param name="pricingModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> CreatePrice(PricingModel pricingModel)
        {
            try
            {
                //check if the price name is already exist
                var price = await _zumbaDbContext.PricingModels.FirstOrDefaultAsync(x => x.PriceName == pricingModel.PriceName);

                if(price != null)
                {
                    _logger.LogError($"Price name {pricingModel.PriceName} is already exist");
                    return new ResponseModel()
                    {
                        Message = string.Format($"Price name {pricingModel.Price} is already exist"),
                        Code = 900
                    };
                }

                //Create a new PricingModel object
                var pricemodel = new PricingModel()
                {
                    PriceName = pricingModel.PriceName,
                    PriceDescription = pricingModel.PriceDescription,
                    Price = pricingModel.Price,
                    DateCreated = DateTime.Now,
                    IsActive = false
                };

                await _zumbaDbContext.PricingModels.AddAsync(pricemodel);

                var result = await _zumbaDbContext.SaveChangesAsync() > 0;

                if (!result)
                {
                    _logger.LogError($"Price not successfully created");
                    return new ResponseModel()
                    {
                        Message = string.Format($"Price not successfully created"),
                        Code = 500
                    };
                }

                _logger.LogInformation($"Price {pricingModel.PriceName} succesfully created.");
                return new ResponseModel()
                {
                    Message = string.Format($"Price {pricingModel.PriceName} succesfully created."),
                    Code = 201
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PricingManager||CreatePrice Message:{ex.Message}");
                return new ResponseModel()
                {
                    Message = string.Format($"Error encountered in PricingManager||CreatePrice Message:{ex.Message}"),
                    Code = 500
                };
            }
        }

        /// <summary>
        /// This will delete an price
        /// </summary>
        /// <param name="priceName"></param>
        /// <returns></returns>
        public async Task<ResponseModel> DeletePrice(string priceName)
        {
            try
            {
                //Check if the activity is exist
                //If exist delete it 
                var price = await _zumbaDbContext.PricingModels.FirstOrDefaultAsync(x => x.PriceName == priceName);

                if (price == null)
                {
                    _logger.LogError($"Price name {priceName} is not exist");
                    return new ResponseModel()
                    {
                        Message = string.Format($"Price name {priceName} is not exist"),
                        Code = 400
                    };
                }

                _zumbaDbContext.Remove(price);

                var result = await _zumbaDbContext.SaveChangesAsync() > 0;

                if (!result)
                {
                    _logger.LogError($"Price {priceName} not successfully deleted");
                    return new ResponseModel()
                    {
                        Message = string.Format($"Price {priceName} not successfully deleted"),
                        Code = 500
                    };
                }

                _logger.LogInformation($"Price {priceName} successfully deleted");
                return new ResponseModel()
                {
                    Message = string.Format($"Price {priceName} succesfully deleted."),
                    Code = 200
                };

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PricingManager||DeletePrice Message:{ex.Message}");
                return new ResponseModel()
                {
                    Message = string.Format($"Error encountered in PricingManager||DeletePrice Message:{ex.Message}"),
                    Code = 500
                };
            }
        }

        /// <summary>
        /// This will get all prices
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PricingModel>> GetAll()
        {
            try
            {
                return await _zumbaDbContext.PricingModels.OrderByDescending(x => x.DateCreated).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PricingManager||GetAll Message:{ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// This will get price by its priceName
        /// </summary>
        /// <param name="priceName"></param>
        /// <returns></returns>
        public async Task<PricingModel> GetPrice(string priceName)
        {
            try
            {
                return await _zumbaDbContext.PricingModels.FirstOrDefaultAsync(x => x.PriceName == priceName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PricingManager||GetActivity Message:{ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// This will update a price
        /// </summary>
        /// <param name="pricingModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> UpdatePrice(PricingModel pricingModel)
        {
            try
            {
                //Check if the priceName exist
                var price = await _zumbaDbContext.PricingModels.FirstOrDefaultAsync(x => x.PriceName == pricingModel.PriceName);

                if (price == null)
                {
                    _logger.LogError($"Price {pricingModel.PriceName} is not exist");
                    return new ResponseModel()
                    {
                        Message = string.Format($"Price {pricingModel.PriceName} is not exist"),
                        Code = 400
                    };
                }

                //Create new PricingModel if there is new value in each properties
                if (pricingModel.PriceName != null)
                {
                    price.PriceName = pricingModel.PriceName;
                }
                if (pricingModel.PriceDescription != null)
                {
                    price.PriceDescription = pricingModel.PriceDescription;
                }
                if (pricingModel.Price > 0)
                {
                    price.Price = pricingModel.Price;
                }
                if (!pricingModel.IsActive)
                {
                    price.IsActive = false;
                }

                //save the upload profile
                var result = await _zumbaDbContext.SaveChangesAsync() > 0;

                if (!result)
                {
                    _logger.LogError($"Price not successfully updated");
                    return new ResponseModel()
                    {
                        Message = string.Format($"Price not successfully updated"),
                        Code = 500
                    };
                }

                _logger.LogInformation($"Price successfully updated");
                return new ResponseModel()
                {
                    Message = string.Format($"Price successfully updated"),
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encountered in PricingManager||UpdatePrice Message:{ex.Message}");
                return new ResponseModel()
                {
                    Message = string.Format($"Error encountered in PricingManager||UpdatePrice Message:{ex.Message}"),
                    Code = 500
                };
            }
        }
    }
}
