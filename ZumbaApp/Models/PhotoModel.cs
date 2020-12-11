using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ZumbaApp.Helper;

namespace ZumbaApp.Models
{
    public class PhotoModel
    {
        [Required(ErrorMessage = "Please upload an image file")]
        [DataType(DataType.Upload)]
        [ValidateFile(new string[] { ".jpg", ".jpeg", ".png" })]
        public IFormFile PhotoFile { get; set; }
    }
}