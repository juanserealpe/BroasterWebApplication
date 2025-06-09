using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroasterWebApp.Entities
{

    public class HomeOrder
    {
        [Key]
        public int IdOrder { get; set; }

        [Required]
        [MaxLength(20)]
        public string IdCustomer { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DeliveryFee { get; set; }

        [ForeignKey("IdOrder")]
        public Order Order { get; set; }

        [ForeignKey("IdCustomer")]
        public HomeCustomer HomeCustomer { get; set; }
    }
}