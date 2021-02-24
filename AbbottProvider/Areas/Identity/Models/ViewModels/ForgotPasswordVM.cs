using System.ComponentModel.DataAnnotations;

namespace DocumentManager.Areas.Identity.Models.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Correo Electrónico *")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido.")]
        public string Email { get; set; }
    }
}
