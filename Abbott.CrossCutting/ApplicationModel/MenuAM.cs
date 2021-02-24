using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentManager.CrossCutting.ApplicationModel
{
    public class MenuAM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Actions { get; set; }
        public string Icons { get; set; }
        public int IcOrderMenuons { get; set; }
        public long? IdFather { get; set; }
    }
}
