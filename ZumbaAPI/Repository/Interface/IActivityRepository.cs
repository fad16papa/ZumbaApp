using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaAPI.Repository.Interface
{
    public interface IActivityRepository<TEntity>
    {
        Task<IEnumerable<ActivitiesModel>> GetAll();
        Task<ActivitiesModel> GetActivity(string activityName);
        Task<ResponseModel> CreateActivity(ActivitiesModel activitiesModel);
        Task<ResponseModel> UpdateActivity(ActivitiesModel activitiesModel);
        Task<ResponseModel> DeleteActivity(string activityName);
    }
}
