﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentManager.CrossCutting.ApplicationModel
{
    public class ConsecutiveConfigAM
    {
        public long Id { get; set; }
        public string Prefix { get; set; }
        public long Consecutive { get; set; }
    }
}
