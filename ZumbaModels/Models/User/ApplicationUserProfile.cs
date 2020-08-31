using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZumbaModels.Models
{
    public class ApplicationUserProfile
    {
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
