using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentManager.API.ApiModel
{
    public class JsonResponse
    {
        public string Type { get; } = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
        public string Title { get; set; } = "Información guardada correctamente.";
        public int Status { get; set; }
        public string TraceId { get; set; }
        public dynamic Errors { get; set; }
        public dynamic Result { get; set; }
    }
}
