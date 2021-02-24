using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("DocumentType")]
    public class DocumentType
    {
        [Column("Id", TypeName = "bigint")]
        [Key]
        public long Id { get; set; }

        [Column("Name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("Code", TypeName = "varchar(4)")]
        public string Code { get; set; }
    }
}
