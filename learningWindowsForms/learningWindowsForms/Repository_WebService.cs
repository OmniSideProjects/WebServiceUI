using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using learningWindowsForms.Interfaces;
using learningWindowsForms.Models;

namespace learningWindowsForms
{
    public class Repository_WebService 
    {
        public List<string> AvailableWebServices () 
        {
            return new List<string>
                        {
                            "/DriverWebService.svc",
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

        //public Request DriverWebService()
        //{
        //    var uris = new List<UriOption>
        //    {
        //        new UriOption("/driver/", new List<Parameter> { new Parameter("DriverID", string.Empty, true) }),
        //        new UriOption("/drivers/", new List<Parameter> {
        //                                                        new Parameter("OrganizationID", string.Empty, false),
        //                                                        new Parameter("ResourceGroupID", string.Empty, false),
        //                                                        new Parameter("IsActive", string.Empty, false),
        //                                                        new Parameter("AsOfDateTime", string.Empty, false),
        //                                                        new Parameter("Limit", string.Empty, false),
        //                                                        new Parameter("Offset", string.Empty, false),
        //                                                        new Parameter("OrganizationSID", string.Empty, false),
        //                                                        new Parameter("ResourceGroupSID", string.Empty, false)
        //                                                     })
        //    };

        //    var driverWS = new Request("/DriverWebService.svc", uris);

        //    return driverWS;
        //}
    }
}
