using System.ComponentModel.DataAnnotations;

namespace ZumbaModels.Models.ApiResponse
{
    public class BlogsEditResponse
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        public string Message { get; set; }

        public int Code { get; set; }
    }
}