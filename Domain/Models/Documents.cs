using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("Document")]
    public class Documents
    {
        [Column("Id", TypeName = "bigint")]
        [Key]
        public long Id { get; set; }

        [Column("Name", TypeName = "varchar(250)")]
        public string Name { get; set; }

        [Column("Contents", TypeName = "varbinary(MAX)")]
        public byte[] Contents { get; set; }

        [Column("Size", TypeName = "bigint")]
        public long Size { get; set; }

        [Column("Pages", TypeName = "int")]
        public int Pages { get; set; }

        [Column("Id_Doc_Type", TypeName = "bigint")]
        public long IdDocType { get; set; }

        [Column("Id_User", TypeName = "nvarchar(450)")]
        public string IdUser { get; set; }

        [Column("Hash", TypeName = "varchar(450)")]
        public string Hash { get; set; }

        [Column("Registration_Date", TypeName = "datetime")]
        public DateTime RegistrationDate { get; set; }

        [Column("Rejection_Observation", TypeName = "varchar(150)")]
        public string RejectionObservation { get; set; }

        [Column("Id_State", TypeName = "bigint")]
        public long IdState { get; set; }

        [ForeignKey("IdDocType")]
        public virtual DocumentType DocumentType { get; set; }

    }
}
