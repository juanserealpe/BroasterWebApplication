using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroasterWebApp.Entities
{

    public class OrderTable
    {
        [Required]
        public int IdOrder { get; set; }

        [Required]
        public int IdTable { get; set; }

        [ForeignKey("IdOrder")]
        public Order Order { get; set; }

        [ForeignKey("IdTable")]
        public Table Table { get; set; }
    }
}
