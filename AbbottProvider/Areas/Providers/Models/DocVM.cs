using DocumentManager.CrossCutting.ApplicationModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocumentManager.Areas.Providers.Models
{
    public class DocVM
    {

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Documento *")]
        public IFormFile UploadedFile { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Tipo de Documento *")]
        public long IdDocumentType { get; set; }

        public List<DocumentsAM> ListDocs { get; set; }
    }
}
