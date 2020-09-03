using System;

namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }  
        public string ActivityLink { get; set; }
        public string ActivityVenue { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}