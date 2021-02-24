using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentManager.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Result { get; set; }

        public ResponseModel()
        {
            Success = false;
            Message = "Error en el servidor.";
        }
    }
}
