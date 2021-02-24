using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("RolMenu")]
    public class RolMenu
    {
        [Column("Id", TypeName = "bigint")]
        [Key]
        public long Id { get; set; }

        [Column("Id_Rol", TypeName = "nvarchar(450)")]
        public string IdRol { get; set; }

        [Column("Id_Menu", TypeName = "bigint")]
        public long IdMenu { get; set; }

        [ForeignKey("IdMenu")]
        public virtual Menu Menu { get; set; }
    }
}
