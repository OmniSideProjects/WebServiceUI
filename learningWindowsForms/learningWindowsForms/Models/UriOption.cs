using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningWindowsForms.Models
{
    public class UriOption
    {
        public string Name { get; set; }
        public List<Parameter> Parameters { get; set; }

        public UriOption(string name, List<Parameter> parameters)
        {
            Name = name;
            Parameters = parameters;
        }
    }
}
