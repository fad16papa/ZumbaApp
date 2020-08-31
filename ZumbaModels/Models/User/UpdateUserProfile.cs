using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZumbaModels.Models.User
{
    public class UpdateUserProfile
    {
        [RegularExpression("^([a-zA-Z0-9 .]*)$", ErrorMessage = "No Special Characters Allowed in First Name")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [RegularExpression("^([a-zA-Z0-9 .]*)$", ErrorMessage = "No Special Characters Allowed in Last Name")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Kindly provide valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
