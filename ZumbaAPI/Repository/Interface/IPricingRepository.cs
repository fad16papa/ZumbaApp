using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaAPI.Repository.Interface
{
    public interface IPricingRepository<TEntity>
    {
        Task<IEnumerable<PricingModel>> GetAll();
        Task<PricingModel> GetPrice(string priceName);
        Task<ResponseModel> CreatePrice(PricingModel pricingModel);
        Task<ResponseModel> UpdatePrice(PricingModel pricingModel);
        Task<ResponseModel> DeletePrice(string priceName);
    }
}
