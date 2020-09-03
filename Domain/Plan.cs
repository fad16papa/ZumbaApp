using System;

namespace Domain
{
    public class Plan
    {
        public Guid Id { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}