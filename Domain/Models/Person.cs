using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Person")]
    public class Person
    {
        [Column("Id", TypeName = "bigint")]
        [Key]
        public long Id { get; set; }

        [Column("Name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("Second_Name", TypeName = "varchar(100)")]
        public string SecondName { get; set; }

        [Column("Surname", TypeName = "varchar(100)")]
        public string Surname { get; set; }

        [Column("Second_Surname", TypeName = "varchar(100)")]
        public string SecondSurname { get; set; }

        [Column("Id_Identification_Type", TypeName = "bigint")]
        public long IdIdentificationType { get; set; }

        [Column("Identification", TypeName = "varchar(20)")]
        public string Identification { get; set; }

        [Column("Phone", TypeName = "varchar(50)")]
        public string Phone { get; set; }

        [Column("Cellphone", TypeName = "varchar(50)")]
        public string Cellphone { get; set; }

        [Column("Id_City", TypeName = "bigint")]
        public long IdCity { get; set; }

        [Column("Birthdate", TypeName = "date")]
        public DateTime Birthdate { get; set; }

        [Column("Birthplace", TypeName = "bigint")]
        public long Birthplace { get; set; }

        [Column("Address", TypeName = "varchar(100)")]
        public string Address { get; set; }

        [Column("Registration_Date", TypeName = "datetime")]
        public DateTime RegistrationDate { get; set; }

        [Column("Id_State", TypeName = "bigint")]
        public long IdState { get; set; }

        [ForeignKey("IdState")]
        public States States { get; set; }

        [ForeignKey("IdIdentificationType")]
        public IdentificationType IdentificationType { get; set; }

        [ForeignKey("IdCity")]
        public City City { get; set; }

    }
}
