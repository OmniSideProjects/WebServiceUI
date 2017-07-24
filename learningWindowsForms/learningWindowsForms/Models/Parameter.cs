using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningWindowsForms.Models
{
    public class Parameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool preQuery { get; set; }

        public Parameter(string name, string value, bool beforeQ)
        {
            Name = name;
            Value = value;
            preQuery = beforeQ;
        }
    }
}
