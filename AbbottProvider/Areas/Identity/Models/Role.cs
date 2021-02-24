using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbbottProvider.Areas.Identity.Models
{
    public class Role : IdentityRole
    {
        [Column("Externals", TypeName = "bit")]
        public Boolean IsExternal { get; set; }

        public ICollection<UsersRoles> UsersRoles { get; set; }

    }
}
