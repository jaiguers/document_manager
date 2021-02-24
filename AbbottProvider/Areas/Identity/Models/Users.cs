using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbbottProvider.Areas.Identity.Models
{
    /// <summary>
    /// Entidad usuario extendida por criterios de negocio
    /// Autor: Jair Guerrero
    /// Fecha: 2020-11-17
    /// </summary>
    public class Users : IdentityUser
    {
        [Column("Id_Person", TypeName = "bigint")]
        public Nullable<long> IdPerson { get; set; }

        [Column("Password_Change_Date", TypeName = "datetime")]
        public DateTime? PasswordChangeDate { get; set; }

        [Column("External", TypeName = "bit")]
        public bool IsExternal { get; set; }

        [Column("Id_State", TypeName = "bigint")]
        public long IdState { get; set; }

        public ICollection<UsersRoles> UsersRoles { get; set; }

        [ForeignKey("IdPerson")]
        public virtual Person Person { get; set; }
    }
}
