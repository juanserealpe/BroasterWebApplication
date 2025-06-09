using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroasterWebApp.Entities{

public class Product
{
    [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }

        [Required]
        [MaxLength(100)]
        public string NameProduct { get; set; }

        [MaxLength(255)]
        public string DescriptionProduct { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        public bool IsActive { get; set; } = true;
}
}