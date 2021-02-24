using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("City")]
    public class City
    {
        [Column("Id", TypeName = "bigint")]
        [Key]
        public long Id { get; set; }

        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column("Code", TypeName = "varchar(5)")]
        public string Code { get; set; }

        [Column("Id_Department", TypeName = "bigint")]
        public long IdDepartment { get; set; }

        [Column("Id_State", TypeName = "bigint")]
        public long IdState { get; set; }

        [ForeignKey("IdDepartment")]
        public Department Department { get; set; }

        [ForeignKey("IdState")]
        public States States { get; set; }

    }
}
