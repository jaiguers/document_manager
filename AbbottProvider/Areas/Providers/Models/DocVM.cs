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
        [Display(Name = "Documento *")]
        public IFormFile UploadedFile { get; set; }
        public List<DocumentsAM> ListDocs { get; set; }
    }
}
