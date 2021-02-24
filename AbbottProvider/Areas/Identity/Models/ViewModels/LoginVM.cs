using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbbottProvider.Areas.Identity.Models.ViewModels
{
    /// <summary>
    /// View model para autenticación de usuario
    /// Autor: Jair Guerrero
    /// Fecha: 2020-11-17
    /// </summary>
    public class LoginVM
    {
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Email *")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Contraseña *")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
