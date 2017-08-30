﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningWindowsForms.Models
{
    public class Parameter
    {
        public int ParameterID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; }
        public bool IsThereQuery { get; set; }
        public bool PreQuery { get; set; }
    }
}
