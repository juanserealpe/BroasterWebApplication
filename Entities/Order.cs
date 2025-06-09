using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroasterWebApp.Entities
{

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrder { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalPrice { get; set; }

        [Required]
        public int IdEmployee { get; set; }

        [Required]
        [MaxLength(10)]
        public string StatusOrder { get; set; } = "Pending";

        [Required]
        [MaxLength(50)]
        public string StatusPayment { get; set; } = "Pending";

        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        [MaxLength(255)]
        public string Notes { get; set; }

        [ForeignKey("IdEmployee")]
        public Employee Employee { get; set; }
    }
}
