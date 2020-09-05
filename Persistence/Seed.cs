using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Francis",
                        UserName = "fad16papa",
                        Email = "fad16papa@gmail.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Biscuit",
                        UserName = "Biscuit",
                        Email = "biscuit@gmail.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Mugsy",
                        UserName = "Mugsy",
                        Email = "mugsy@gmail.com"
                    },
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Sixteen@16");
                }
            }
        }
    }
}