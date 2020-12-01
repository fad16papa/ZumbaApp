using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaApp.Repository.Interfaces
{
    public interface IPhotoInterface
    {
        Task<ResponseModel> AddUserPhoto(IFormFile formFile, string token);
    }
}