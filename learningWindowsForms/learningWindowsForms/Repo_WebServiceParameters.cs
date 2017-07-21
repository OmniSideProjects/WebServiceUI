using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using learningWindowsForms.Interfaces;
using learningWindowsForms.Models;

namespace learningWindowsForms
{
    public class Repo_WebServiceParameters : IRepo_WebServiceParameters
    {
        public List<string> AvailableWebServices () 
        {
            return new List<string>
                        {
                            "/DriverWebService",
                        };
        }

        public List<string> DriverUris()
        {
            return new List<string>
            {
                "/driver/",
                "/drivers/",
            };
        }

        public List<string> GetAllDriversParameters ()
        {
            return new List<string>
                        {
                            "OrganizationID",
                            "ResourceGroupID",
                            "IsActive",
                            "AsOfDateTime",
                            "Limit",
                            "Offset",
                            "OrganizationSID",
                            "ResourceGroupSID",
                        };

        }

        public List<string> GetOneDriverParameters ()
        {
            return new List<string>
                        {
                            "DriverID",
                        };
        }

        public WebService DriverWebService()
        {
            var uris = new List<UriOption>
            {
                new UriOption("/driver/", new List<string> { "DriverID" }),
                new UriOption("/drivers/", new List<string> {
                                                                "OrganizationID",
                                                                "ResourceGroupID",
                                                                "IsActive",
                                                                "AsOfDateTime",
                                                                "Limit",
                                                                "Offset",
                                                                "OrganizationSID",
                                                                "ResourceGroupSID",
                                                             })
            };

            var driverWS = new WebService("Driver Web Service", uris);

            return driverWS;
        }
    }
}
