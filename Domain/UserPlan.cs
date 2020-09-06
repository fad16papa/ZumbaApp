using System;

namespace Domain
{
    public class UserPlan
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public Guid PlanId { get; set; }
        public virtual Plan Plan { get; set; }
    }
}