using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZumbaAPI.Repository.Interface;

namespace ZumbaAPI.Repository.DataManager
{
    public class UserAccessorManager : IUserAccessorRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessorManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}
