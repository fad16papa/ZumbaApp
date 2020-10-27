using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZumbaModels.Models
{
    public class PlanModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string PriceName { get; set; }
        [Required]
        public string PriceDescription { get; set; }
        [Required]
        public bool UnlimitedSession { get; set; }
        [Required]
        public bool VIPAccess { get; set; }
        [Required]
        public bool Mentorship { get; set; }
        [Required]
        public bool Billing { get; set; }
        [Required]
        public bool Invoicing { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
