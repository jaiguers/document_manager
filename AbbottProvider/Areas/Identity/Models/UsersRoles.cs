using Microsoft.AspNetCore.Identity;

namespace DocumentManager.Areas.Identity.Models
{
    /// <summary>
    /// Entidad IdentityUserRole extendida por criterios de negocio
    /// Autor: Jair Guerrero
    /// Fecha: 2020-11-17
    /// </summary>
    public class UsersRoles : IdentityUserRole<string>
    {
        public virtual Users Users { get; set; }
        public virtual Role Role { get; set; }
    }
}
