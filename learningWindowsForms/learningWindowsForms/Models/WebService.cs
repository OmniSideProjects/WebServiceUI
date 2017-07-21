using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningWindowsForms.Models
{
    public class WebService
    {
        public string Name { get; set; }
        public List<UriOption> Uris { get; set; }

        public WebService(string name, List<UriOption> uris)
        {
            Name = name;
            Uris = uris;
        }
    }
}
