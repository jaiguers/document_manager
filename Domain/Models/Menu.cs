using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Column("Id", TypeName = "bigint")]
        [Key]
        public long Id { get; set; }

        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column("Area", TypeName = "varchar(50)")]
        public string Area { get; set; }

        [Column("Controller", TypeName = "varchar(50)")]
        public string Controller { get; set; }

        [Column("Actions", TypeName = "varchar(50)")]
        public string Actions { get; set; }

        [Column("Icons", TypeName = "varchar(50)")]
        public string Icons { get; set; }

        [Column("OrderMenu", TypeName = "int")]
        public int IcOrderMenuons { get; set; }

        [Column("IdFather", TypeName = "bigint")]
        public long? IdFather { get; set; }
    }
}
