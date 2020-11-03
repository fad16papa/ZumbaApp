using System;
using System.ComponentModel.DataAnnotations;

namespace ZumbaModels.Models.ApiResponse
{
    public class UserDetailsResponseModel
    {
        [Required]
        [RegularExpression("^([a-zA-Z0-9-]*)$", ErrorMessage = "No Special Characters allowed")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z]*)$", ErrorMessage = "No Special Characters or Numeric allowed in First Name")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z]*)$", ErrorMessage = "No Special Characters or Numeric allowed in Last Name")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Kindly provide a valid email address!")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z ]*)$", ErrorMessage = "No Special Characters or Numeric allowed in Country")]
        [StringLength(50)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z ]*)$", ErrorMessage = "No Special Characters or Numeric allowed in City")]
        [StringLength(50)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [RegularExpression("^[0-9+]+$", ErrorMessage = "No Special Characters and Alphabets allowed in MobileNumber")]
        [StringLength(50)]
        [Display(Name = "MobileNumber")]
        public string MobileNumber { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z0-9 .]*)$", ErrorMessage = "No Special Characters allowed in DisplayName")]
        [StringLength(50)]
        [Display(Name = "DisplayName")]
        public string DisplayName { get; set; }

        [StringLength(500)]
        [Display(Name = "Profile Text")]
        public string ProfileText { get; set; }

        public string Message { get; set; }

        public int Code { get; set; }
    }
}