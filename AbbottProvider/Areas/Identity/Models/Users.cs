using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentManager.Areas.Identity.Models
{
    /// <summary>
    /// Entidad usuario extendida por criterios de negocio
    /// Autor: Jair Guerrero
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
