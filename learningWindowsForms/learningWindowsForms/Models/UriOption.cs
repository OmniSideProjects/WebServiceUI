﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningWindowsForms.Models
{
    public class UriOption
    {
        public int UriOptionID { get; set; }
        public string Name { get; set; }
        public List<Parameter> Parameters { get; set; }

    }
}
