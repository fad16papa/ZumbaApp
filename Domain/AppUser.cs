using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Photos = new Collection<Photo>();
        }

        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfileText { get; set; }
        public virtual ICollection<UserActivity> UserActivities { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<UserFollowing> Followings { get; set; }
        public virtual ICollection<UserFollowing> Followers { get; set; }
    }
}