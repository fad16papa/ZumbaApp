using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ZumbaApp.Models
{
    public class PhotoModel
    {
        [Required]
        public IFormFile PhotoFile { get; set; }
    }
}