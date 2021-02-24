using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Department")]
    public class Department
    {
        [Column("Id", TypeName = "bigint")]
        [Key]
        public long Id { get; set; }

        [Column("Name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("Code", TypeName = "varchar(2)")]
        public string Code { get; set; }

        [Column("Id_State", TypeName = "bigint")]
        public long IdState { get; set; }

        [ForeignKey("IdState")]
        public States States { get; set; }

    }
}
