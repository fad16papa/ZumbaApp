using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Interfaces
{
    public interface IUserInterface
    {
        Task<LoginResponseModel> RegisterUser(RegisterModel registerModel);
        Task<LoginResponseModel> LoginUser(LoginModel loginModel);
        Task<UserDetailsResponseModel> GetUserDetails(string userName, string token);
        Task<UserResponseModel> GetCurrentUser(string token);

        Task<UserDetailsResponseModel> UpdateUserDetails(UserDetailsResponseModel model, string token);
    }
}
