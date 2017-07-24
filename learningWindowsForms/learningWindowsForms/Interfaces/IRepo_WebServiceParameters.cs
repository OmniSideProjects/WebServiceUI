using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using learningWindowsForms.Models;

namespace learningWindowsForms.Interfaces
{
    public interface IRepo_WebServiceParameters
    {
        List<string> AvailableWebServices();
        List<string> GetAllDriversParameters();
        List<string> GetOneDriverParameters();
        List<string> DriverUris();
        WebServiceRequest DriverWebService();

    }
}
