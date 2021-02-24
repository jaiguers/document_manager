using System;
using System.ComponentModel.DataAnnotations;

namespace DocumentManager.CrossCutting.ApplicationModel
{
    public class PersonAM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Nombre *")]
        public string Name { get; set; }
        [Display(Name = "Segundo nombre")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Apellido *")]
        public string SurName { get; set; }

        [Display(Name = "Segundo apellido")]
        public string SecondSurName { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Tipo de identificación *")]
        public long IdIdentificationType { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Número de identificación *")]
        public string Identification { get; set; }

        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Celular *")]
        public string Cellphone { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Departamento de residencia *")]
        public long IdDepartment { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Ciudad de residencia *")]
        public long IdCity { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Fecha de nacimiento *")]
        public DateTime? Birthdate { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Departamento de nacimiento *")]
        public long IdDepartPlace { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Lugar de nacimiento *")]
        public long Birthplace { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Dirección *")]
        public string Address { get; set; }
        public long IdState { get; set; }
        public StatesAM States { get; set; }
        public IdentificationTypeAM IdentificationType { get; set; }
        public CityAM City { get; set; }
    }
}
