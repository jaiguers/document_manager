using System;
using System.Collections.Generic;
using System.Text;

namespace Abbott.CrossCutting.ApplicationModel
{
    public class RolMenuAM
    {
        public long Id { get; set; }
        public string IdRol { get; set; }
        public long IdMenu { get; set; }
        public virtual MenuAM Menu { get; set; }
    }
}
