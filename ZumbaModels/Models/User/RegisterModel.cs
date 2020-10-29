using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZumbaModels.Models
{
    public class RegisterModel
    {
        [Required]
        [RegularExpression("^([a-zA-Z0-9-]*)$", ErrorMessage = "No Special Characters Allowed")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z0-9 .]*)$", ErrorMessage = "No Special Characters Allowed in First Name")]
        [StringLength(50)]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Kindly provide valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z0-9 .]*)$", ErrorMessage = "No Special Characters Allowed in First Name")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z0-9 .]*)$", ErrorMessage = "No Special Characters Allowed in Last Name")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Error Password Format. Should contians at least 1 Upper Case, 1 Lower Case, 1 Numeric and 1 Special Character.")]
        [DataType(DataType.Password, ErrorMessage = "Kindly provide a valid password!")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again!")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Profile Text")]
        public string ProfileText { get; set; }
    }
}
