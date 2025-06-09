using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroasterWebApp.Entities
{

    public class Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTable { get; set; }

        [Required]
        [MaxLength(50)]
        public string TableName { get; set; }

        [Required]
        public int XPosition { get; set; }

        [Required]
        public int YPosition { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Free";

        [Required]
        public int Capacity { get; set; }

        [MaxLength(50)]
        public string Shape { get; set; }

        public int Rotation { get; set; } = 0;
    }
}