using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain
{
    public class Blog
    {
        public Blog()
        {
            BlogPhotos = new Collection<BlogPhoto>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<BlogPhoto> BlogPhotos { get; set; }
    }
}