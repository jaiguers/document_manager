using System.ComponentModel.DataAnnotations;

namespace DocumentManager.Areas.Identity.Models.ViewModels
{
    public class RecoverPasswordVM
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string RecoverToken { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nueva contraseña *")]
        [StringLength(15, ErrorMessage = "Debe tener entre 7 y 15 caracteres", MinimumLength = 7)]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[!@@#$\\_.%^&*])[a-zA-Z0-9!@@#$\\_.%^&*]{7,15}$", ErrorMessage = "* Debe tener entre 7 y 15 caracteres.<br>* Debe contener al menos una letra mayuscula y una minuscula.<br>* Debe contener al menos un número.<br>* Debe contener un carácter especial.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Confirmar password *")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string RepeatPassword { get; set; }
    }
}
