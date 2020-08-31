using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Interfaces
{
    public interface IUserInterface
    {
        Task<ResponseModel> RegisterUser(RegisterModel registerModel);

        Task<ResponseModel> LoginUser(LoginModel loginModel);
    }
}
