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
        public string Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEnd { get; set; }
        public ICollection<UserPlan> UserPlans { get; set; }
    }
}