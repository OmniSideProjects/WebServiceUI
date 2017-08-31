using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningWindowsForms.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public string Name { get; set; }
        public List<UriOption> UriOptions { get; set; }

        public Request()
        {
            UriOptions = new List<UriOption>();
        }
    }
}
