using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Consecutive_Config")]
    public class ConsecutiveConfig
    {
        [Column("Id", TypeName = "bigint")]
        [Key]
        public long Id { get; set; }

        [Column("Prefix", TypeName = "varchar(2)")]
        public string Prefix { get; set; }

        [Column("Consecutive", TypeName = "bigint")]
        public long Consecutive { get; set; }
    }
}
