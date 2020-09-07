using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Plan
    {
        public Guid Id { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public bool UnlimitedSession { get; set; }
        public bool VIPAccess { get; set; }
        public bool Mentorship { get; set; }
        public bool Billing { get; set; }
        public bool Invoicing { get; set; }
        public string Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<UserPlan> UserPlans { get; set; }
    }
}