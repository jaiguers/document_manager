using DocumentManager.CrossCutting.ApplicationModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentManager.Areas.Providers.Models
{
    public class DocVM
    {

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Copia de cédula *")]
        public IFormFile UploadedFileCC { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Hoja de vida *")]
        public IFormFile UploadedFileHv { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "ARL *")]
        public IFormFile UploadedFileARL { get; set; }
        public List<DocumentsAM> ListDocs { get; set; }
    }
}
