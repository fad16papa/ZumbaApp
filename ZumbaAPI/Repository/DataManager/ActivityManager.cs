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
    /// Description: This will handle the data factory for ActivitiesModel 
    /// </summary>
    public class ActivityManager : IActivityRepository<ActivitiesModel>
    {
        #region Properties
        private readonly ILogger<ActivityManager> _logger;
        private readonly ZumbaDbContext _zumbaDbContext;
        private readonly IConfiguration _configuration;
        #endregion

        #region Contructor
        public ActivityManager(ILogger<ActivityManager> logger, ZumbaDbContext zumbaDbContext, IConfiguration configuration)
        {
            _logger = logger;
            _zumbaDbContext = zumbaDbContext;
            _configuration = configuration;
        }
        #endregion

        public Task<ResponseModel> CreateActivity(ActivitiesModel activitiesModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteActivity(string activityName)
        {
            throw new NotImplementedException();
        }

        public Task<ActivitiesModel> GetActivity(string activityName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ActivitiesModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdateActivity(ActivitiesModel activitiesModel)
        {
            throw new NotImplementedException();
        }
    }
}
