using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;
using ZumbaModels.Models.User;

namespace ZumbaAPI.Repository.Interface
{
    public interface IApplicationUserRepository<TEntity>
    {
        Task<IEnumerable<ApplicationUser>> GetAll();
        Task<ApplicationUser> GetUser(string userName);
        Task<ResponseModel> AuthenticateUser(LoginModel loginModel);
        Task<ResponseModel> RegisterUser(RegisterModel registerModel);
        Task<ResponseModel> UpdateUser(ClaimsPrincipal claimsPrincipal, UpdateUserProfile updateUserProfile);
    }
}
