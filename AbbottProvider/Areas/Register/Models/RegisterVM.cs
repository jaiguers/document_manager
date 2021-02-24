using DocumentManager.CrossCutting.ApplicationModel;
using System.ComponentModel.DataAnnotations;

namespace DocumentManager.Areas.Register.Models
{
    public class RegisterVM
    {

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Email *")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Contraseña *")]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Debe tener entre 7 y 15 caracteres")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[!@@#$\\_.%^&*])[a-zA-Z0-9!@@#$\\_.%^&*]{7,15}$", ErrorMessage = "* Debe tener entre 7 y 15 caracteres.<br>* Debe contener al menos una letra mayúscula y una minúscula.<br>* Debe contener al menos un número.<br>* Debe contener un carácter especial.")]
        public string Password { get; set; }

        public PersonAM Person { get; set; }
    }
}
