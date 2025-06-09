using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroasterWebApp.Entities
{

        public class RoleType
        {
                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("id_role_type")]
                public int IdRoleType { get; set; }

                [Required]
                [MaxLength(50)]
                [Column("type_role")]
                public string TypeRole { get; set; }

                public ICollection<Role> Roles { get; set; } = new List<Role>();
        }
}
