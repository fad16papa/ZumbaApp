using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZumbaModels.Models
{
    public class PricingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string PriceName { get; set; }
        public string PriceDescription { get; set; }
        public Decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public ActivitiesModel ActivitiesModel { get; set; }
    }
}
