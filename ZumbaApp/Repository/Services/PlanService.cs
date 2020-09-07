using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using ZumbaApp.Repository.Interfaces;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Services
{
    public class PlanService : IPlanInterface
    {
        private readonly ILogger<PlanService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public PlanService(ILogger<PlanService> logger, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public Task<ResponseModel> CreatePlan(PlanModel planModel, string token)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeletePlan(Guid id, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PlanModel>> GetAll(string token)
        {
            try
            {
               var responseClient = _httpClientFactory.CreateClient("ZumbaAPI");

               responseClient.DefaultRequestHeaders.Add("Bearer", token);

               var result = await responseClient.GetAsync("api/Plan");

               if (result.StatusCode != HttpStatusCode.OK)
               {
                   
               }

               return await result.Content.ReadAsJsonAsync<IEnumerable<PlanModel>>();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Task<PlanModel> GetPlan(Guid id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdatePlan(Guid id, PlanModel planModel, string token)
        {
            throw new NotImplementedException();
        }
    }
}