using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZumbaModels.Models;

namespace ZumbaAPI.DBContext
{
    public class ZumbaDbContext : IdentityDbContext<ApplicationUser>
    {
        public ZumbaDbContext(DbContextOptions<ZumbaDbContext> options) : base(options)
        {
        }

        public DbSet<PricingModel> PricingModels { get; set; }
        public DbSet<ActivitiesModel> ActivitiesModels { get; set; }
    }
}
