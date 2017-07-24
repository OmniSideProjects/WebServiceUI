﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningWindowsForms.Models
{
    public class WebServiceRequest
    {
        public string Name { get; set; }
        public List<UriOption> Uris { get; set; }

        public WebServiceRequest(string name, List<UriOption> uris)
        {
            Name = name;
            Uris = uris;
        }
    }
}