using System;
using System.Threading.Tasks;

namespace ZumbaApp.Repository.Interfaces
{
    public interface IBlogsPhotoInterface
    {
        Task<object> AddBlogPhoto(string token, Guid Id);
    }
}