using System;
using System.Collections.Generic;
using System.Text;

namespace Abbott.CrossCutting.ApplicationModel
{
    public class DocumentsAM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte[] Contents { get; set; }
        public long Size { get; set; }
        public int Pages { get; set; }
        public long IdDocType { get; set; }
        public string IdUser { get; set; }
        public string Hash { get; set; }
        public string RejectionObservation { get; set; }
        public DateTime RegistrationDate { get; set; }
        public long IdState { get; set; }
        public DocumentTypeAM DocumentType { get; set; }
    }
}
