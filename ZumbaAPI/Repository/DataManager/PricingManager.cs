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

        public Task<ResponseModel> CreatePrice(PricingModel pricingModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeletePrice(string priceName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PricingModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PricingModel> GetPrice(string priceName)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdatePrice(PricingModel pricingModel)
        {
            throw new NotImplementedException();
        }
    }
}
