using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Interfaces
{
    public interface IPlanInterface
    {
         Task<IEnumerable<PlanModel>> GetAll(string token);
         Task<PlanModel> GetPlan(Guid id, string token);
         Task<ResponseModel> CreatePlan(PlanModel planModel, string token);
         Task<ResponseModel> UpdatePlan(Guid id, PlanModel planModel, string token);
         Task<ResponseModel> DeletePlan(Guid id, string token);
    }
}