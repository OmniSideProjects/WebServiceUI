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
        public bool PreQuery { get; set; }
        public bool Required { get; set; }
        //This is to handle segements in different URLs
        public string PostCharacters { get; set; }
    }
}
