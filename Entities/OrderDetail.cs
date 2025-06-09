using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroasterWebApp.Entities
{

    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetail { get; set; }

        [Required]
        public int IdOrder { get; set; }

        [Required]
        public int IdProduct { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal Subtotal { get; private set; } // Calculado automáticamente

        [MaxLength(255)]
        public string Notes { get; set; }

        [ForeignKey("IdOrder")]
        public Order Order { get; set; }

        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
    }

}