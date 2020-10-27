using System;
using System.ComponentModel.DataAnnotations;

namespace ZumbaModels.Models.ApiResponse
{
    public class UserDetailsResponseModel
    {
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public string DisplayName { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}