using System;
using System.IO;
using learningWindowsForms.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using learningWindowsForms.Interfaces;

namespace learningWindowsForms.DAL.Repositories
{
    public class RequestRepository : BaseRepository, IRequestRepo
    {
        private List<Request> _allRequests;

        public RequestRepository()
        {
            _allRequests = new List<Request>();
            //RemoveOldFile();
            //CreateDatabaseTables();
            LoadData();
        }

        #region Initialize Database

        public void InitializeDatabase()
        {
            RemoveOldFile();
            CreateDatabaseTables();
        }

        public void RemoveOldFile()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WebServiceUI");

            //Delete old directory/file
            if (Directory.Exists(filePath))
            {
                try
                {
                    var dir = new DirectoryInfo(filePath);
                    dir.Delete(true);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //Create new directory/file
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WebServiceUI"));

        }

        public void CreateDatabaseTables()
        {
            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                connection.Execute(
                           @"CREATE TABLE Request
                            (
                                RequestID       INTEGER PRIMARY KEY,
                                Name            varchar(50) NOT NULL
                            );
                            CREATE TABLE UriOption
                            (
                                UriOptionID     INTEGER PRIMARY KEY,
                                Name            varchar(50) NOT NULL,
                                Value           varchar(50) NOT NULL,
                                ThereIsQuery    boolean NOT NULL,
                                RequestID       INTEGER NOT NULL,
                                FOREIGN KEY     (RequestID) REFERENCES Request(RequestID)
                            );
                            CREATE TABLE Parameter
                            (
                                ParameterID     INTEGER PRIMARY KEY,
                                Name            varchar(30) NOT NULL,
                                PreQuery        boolean NOT NULL,
                                Required        boolean,
                                UriOptionID     INTEGER NOT NULL,
                                FOREIGN KEY     (UriOptionID) REFERENCES UriOption(UriOptionID)
                            );");
            }
        }

        private void LoadData()
        {
            //TODO: Update UriOption/Database to account for Uris that have dual segments: /messsages/{MESSAGESID}/attachment/{ImageSID}
            //Affects:
            //MessageWebService.svc
            //RouteWebService.svc
            List<Request> requests = new List<Request>()
            {
                //BlackBoxWebService.svc
                new Request()
                {
                    Name = "/BlackBoxWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/blackboxsummary/",
                            Value = "/blackboxsummary/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false },
                                new Parameter() { Name = "StartDate", PreQuery = false },
                                new Parameter() { Name = "EndDate", PreQuery = false },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                                new Parameter() { Name = "IncludeHistory", PreQuery = false },
                                new Parameter() { Name = "OnlyShowEventsWithVideo", PreQuery = false },
                                new Parameter() { Name = "OrderDirection", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false },
                                new Parameter() { Name = "Offset", PreQuery = false },
                            }
                        },
                        new UriOption()
                        {
                            Name = "/blackboxsummary/driver/{DriverID}",
                            Value = "/blackboxsummary/driver/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "DriverID", PreQuery = true, Required = true},
                                new Parameter() { Name = "StartDate", PreQuery = false },
                                new Parameter() { Name = "EndDate", PreQuery = false },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                                new Parameter() { Name = "IncludeHistory", PreQuery = false },
                                new Parameter() { Name = "OnlyShowEventsWithVideo", PreQuery = false },
                                new Parameter() { Name = "OrderDirection", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false },
                                new Parameter() { Name = "Offset", PreQuery = false },
                            }
                        },
                        new UriOption()
                        {
                            Name = "/blackboxsummary/vehicle/{VehicleID}",
                            Value = "/blackboxsummary/vehicle/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = true},
                                new Parameter() { Name = "StartDate", PreQuery = false },
                                new Parameter() { Name = "EndDate", PreQuery = false },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                                new Parameter() { Name = "IncludeHistory", PreQuery = false },
                                new Parameter() { Name = "OnlyShowEventsWithVideo", PreQuery = false },
                                new Parameter() { Name = "OrderDirection", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false },
                                new Parameter() { Name = "Offset", PreQuery = false },
                            }
                        },

                    }
                },
                //DelayDetailReportWebService.svc
                new Request()
                {
                    Name = "/DelayDetailReportWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/DelayDetail/",
                            Value = "/DelayDetail/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false },
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false },
                                new Parameter() { Name = "DriverID", PreQuery = false },
                                new Parameter() { Name = "RouteID", PreQuery = false },
                                new Parameter() { Name = "DelayReason", PreQuery = false },
                                new Parameter() { Name = "StartDateTime", PreQuery = false },
                                new Parameter() { Name = "EndDateTime", PreQuery = false },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false },
                                new Parameter() { Name = "Offset", PreQuery = false },
                                new Parameter() { Name = "Recurse", PreQuery = false },

                            }
                        }
                    }
                },
                //DelaySummaryReportWebService.svc
                new Request()
                {
                    Name = "/DelaySummaryReportWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/DelaySummary/",
                            Value = "/DelaySummary/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false },
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false },
                                new Parameter() { Name = "DriverID", PreQuery = false },
                                new Parameter() { Name = "RouteID", PreQuery = false },
                                new Parameter() { Name = "DelayReason", PreQuery = false },
                                new Parameter() { Name = "StartDateTime", PreQuery = false },
                                new Parameter() { Name = "EndDateTime", PreQuery = false },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false },
                                new Parameter() { Name = "Offset", PreQuery = false },
                                new Parameter() { Name = "Recurse", PreQuery = false },

                            }
                        }
                    }
                },
                //DeviceWebService.svc
                new Request()
                {
                    Name = "/DeviceWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/device/{PhoneNumber}",
                            Value = "/device/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "PhoneNumber", PreQuery = true, Required = true },
                            }
                        },
                        new UriOption()
                        {
                            Name = "/devices/",
                            Value = "/devices/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false },
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false },
                                new Parameter() { Name = "IsActive", PreQuery = false },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false },
                                new Parameter() { Name = "Offset", PreQuery = false },
                            }
                        }

                    }
                },
                //DriverLogWebService.svc
                new Request()
                {
                    Name = "/DriverLogWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/driverlog/",
                            Value = "/driverlog/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false, Required = true},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false },
                                new Parameter() { Name = "Edits", PreQuery = false },
                                new Parameter() { Name = "StartDate", PreQuery = false },
                                new Parameter() { Name = "EndDate", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false },
                                new Parameter() { Name = "Offset", PreQuery = false },

                            }
                        },
                        new UriOption()
                        {
                            Name = "/driverlog/{DriverID}",
                            Value = "/driverlog/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", PreQuery = true, Required = true },
                                new Parameter() { Name = "Edits", PreQuery = false },
                                new Parameter() { Name = "StartDate", PreQuery = false },
                                new Parameter() { Name = "EndDate", PreQuery = false },
                            }
                        },
                        new UriOption()
                        {
                            Name = "/driverlogdetails/",
                            Value = "/driverlogdetails/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false },
                                new Parameter() { Name = "Offset", PreQuery = false },

                            }
                        },
                        new UriOption()
                        {
                            Name = "/driverlogdetails/{DriverID}",
                            Value = "/driverlogdetails/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", PreQuery = true, Required = true },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                            }
                        }


                    }
                },
                //DriverStatusWebService.svc
                new Request()
                {
                    Name = "/DriverStatusWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/driverstate/{DriverID}",
                            Value = "/driverstate/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", PreQuery = true, Required = true },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                            }
                        },
                        new UriOption()
                        {
                            Name = "/driverstatus/",
                            Value = "/driverstatus/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationSID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupSID", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "IsActive",  PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                                new Parameter() { Name = "Options", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/driverstatus/{DriverSID}",
                            Value = "/driverstatus/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverSID", PreQuery = true, Required = true },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                            }
                        },
                    }
                },
                //DriverWebService.svc
                new Request()
                {
                    Name = "/DriverWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/driver/{DriverID}",
                            Value = "/driver/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", PreQuery = false}
                            }
                        },
                        new UriOption()
                        {
                            Name = "/drivers/",
                            Value = "/drivers/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "ResourceGroupSID", PreQuery = false},
                                new Parameter() { Name = "OrganizationSID", PreQuery = false},
                                new Parameter() { Name = "IsActive",  PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/drivers/{DriverSID}",
                            Value = "/drivers/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverSID", PreQuery = true, Required = true}
                            }
                        },


                    }
                },
                //DVIRWebService.svc
                new Request()
                {
                    Name = "/DVIRWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/DVIR/",
                            Value = "/DVIR/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate",  PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "DriverID", PreQuery = false},
                                new Parameter() { Name = "AssetType", PreQuery = false},
                                new Parameter() { Name = "InspectionsWithDefectsOnly", PreQuery = false},
                                new Parameter() { Name = "IncludeNonDefects", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/DVIR/trailer/{TrailerID}",
                            Value = "/DVIR/trailer/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "TrailerID", PreQuery = false},
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate",  PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "DriverID", PreQuery = false},
                                new Parameter() { Name = "InspectionsWithDefectsOnly", PreQuery = false},
                                new Parameter() { Name = "IncludeNonDefects", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/DVIR/trailer/{VehicleID}",
                            Value = "/DVIR/trailer/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = false},
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate",  PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "DriverID", PreQuery = false},
                                new Parameter() { Name = "InspectionsWithDefectsOnly", PreQuery = false},
                                new Parameter() { Name = "IncludeNonDefects", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                    }
                },
                //FaultCodeWebService.svc
                new Request()
                {
                    Name = "/FaultCodeWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/FaultCodes/",
                            Value = "/FaultCodes/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate",  PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/FaultCodes/vehicle/{VehicleID}",
                            Value = "/FaultCodes/vehicle/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = true, Required = true},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate",  PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                    }
                },
                //FormTemplateCategoryWebService.svc
                new Request()
                {
                    Name = "/FormTemplateCategoryWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/formcategories/",
                            Value = "/formcategories/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/formcategories/{FormTemplateCategorySID}",
                            Value = "/formcategories/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "FormTemplateCategorySID", PreQuery = true, Required = true},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/formcategory/{FormTemplateCategoryID}",
                            Value = "/formcategory/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "FormTemplateCategoryID", PreQuery = true, Required = true},
                            }
                        },
                    }
                },
                //FormTemplateContentWebService.svc
                new Request()
                {
                    Name = "/FormTemplateContentWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/formtemplatecontent/",
                            Value = "/formtemplatecontent/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "FormCategorySID", PreQuery = false},
                                new Parameter() { Name = "InProduction", PreQuery = false},
                                new Parameter() { Name = "IsActive", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "FormCategoryID", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/formtemplatecontent/{FormNumber}",
                            Value = "/formtemplatecontent/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "FormNumber", PreQuery = true, Required = true},
                            }
                        },
                    }
                },
                //FormTemplateHeaderWebService.svc
                new Request()
                {
                    Name = "/FormTemplateHeaderWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/formtemplateheader/",
                            Value = "/formtemplateheader/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "FormCategorySID", PreQuery = false},
                                new Parameter() { Name = "InProduction", PreQuery = false},
                                new Parameter() { Name = "IsActive", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "FormCategoryID", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/formtemplateheader/{FormNumber}",
                            Value = "/formtemplateheader/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "FormNumber", PreQuery = true, Required = true},
                            }
                        },
                    }
                },
                //IFTAWebService.svc
                new Request()
                {
                    Name = "/IFTAWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/Distances/",
                            Value = "/Distances/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "StartDateTime", PreQuery = false},
                                new Parameter() { Name = "EndDateTime", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "StateProvince", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "FormCategoryID", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/Distances/{vehicleId}",
                            Value = "/Distances/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = true, Required = true},
                                new Parameter() { Name = "StartDateTime", PreQuery = false},
                                new Parameter() { Name = "EndDateTime", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/FuelReceipts/",
                            Value = "/FuelReceipts/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationId", PreQuery = true, Required = true},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "StateProvince", PreQuery = false},
                                new Parameter() { Name = "Vendor", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/FuelReceipts/{vehicleId}",
                            Value = "/FuelReceipts/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleId", PreQuery = true, Required = true},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/JurisdictionCrossings/",
                            Value = "/JurisdictionCrossings/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationId", PreQuery = true, Required = true},
                                new Parameter() { Name = "StartDateTime", PreQuery = false},
                                new Parameter() { Name = "EndDateTime", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/JurisdictionCrossings/{vehicleId}",
                            Value = "/JurisdictionCrossings/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleId", PreQuery = true, Required = true},
                                new Parameter() { Name = "StartDateTime", PreQuery = false},
                                new Parameter() { Name = "EndDateTime", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                    }
                },
                //TODO: Update UriOption/Database to account for Uris that have dual segments: /messsages/{MESSAGESID}/attachment/{ImageSID}
                //MessageWebService.svc
                new Request()
                {
                    Name = "/MessageWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/messages/",
                            Value = "/messages/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "MessageType", PreQuery = false},
                                new Parameter() { Name = "FormNumber", PreQuery = false},
                                new Parameter() { Name = "IncludeImageData", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "OrderDirection", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/messages/{MessageSID}",
                            Value = "/messages/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "MessageSID", PreQuery = true, Required = true},
                                new Parameter() { Name = "IncludeImageData", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/messages/read",
                            Value = "/messages/read",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "MessageType", PreQuery = false},
                                new Parameter() { Name = "FormNumber", PreQuery = false},
                                new Parameter() { Name = "IncludeImageData", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "OrderDirection", PreQuery = false},
                                new Parameter() { Name = "MessageSID", PreQuery = false},
                                new Parameter() { Name = "ImageSID", PreQuery = false},
                                new Parameter() { Name = "StartDateTime", PreQuery = false},
                                new Parameter() { Name = "EndDateTime", PreQuery = false},

                            }
                        },
                        new UriOption()
                        {
                            Name = "/messages/status/",
                            Value = "/messages/status/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "MessageType", PreQuery = false},
                                new Parameter() { Name = "FormNumber", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/messages/status/{MessageSID}",
                            Value = "/messages/status/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "MessageSID", PreQuery = true, Required = true},
                            }
                        },
                    }
                },
                //OperationWebService.svc
                new Request()
                {
                    Name = "/OperationWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/Profile/",
                            Value = "/Profile/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "GroupBy", PreQuery = false},
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "IsActive", PreQuery = false},
                                new Parameter() { Name = "IncludeHistory", PreQuery = false},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/Profile/driver/{DriverID}",
                            Value = "/Profile/driver/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", PreQuery = true, Required = true},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/Profile/vehicle/{VehicleID}",
                            Value = "/Profile/vehicle/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = true, Required = true},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/Summary/",
                            Value = "/Summary/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "GroupBy", PreQuery = false},
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "IsActive", PreQuery = false},
                                new Parameter() { Name = "IncludeHistory", PreQuery = false},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/Summary/driver/{DriverID}",
                            Value = "/Summary/driver/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", PreQuery = true, Required = true},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/Summary/vehicle/{VehicleID}",
                            Value = "/Summary/vehicle/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = true, Required = true},
                                new Parameter() { Name = "StartDate", PreQuery = false},
                                new Parameter() { Name = "EndDate", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                            }
                        },

                    }
                },
                //OrganizationWebService.svc
                new Request()
                {
                    Name = "/OrganizationWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/organization/{SID}",
                            Value = "/organization/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationSID", PreQuery = true, Required = true}
                            }
                        },
                        new UriOption()
                        {
                            Name = "/organizations/",
                            Value = "/organizations/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationSid", PreQuery = false},
                                new Parameter() { Name = "Status", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "OrganizationId", PreQuery = false}
                            }
                        },
                        new UriOption()
                        {
                            Name = "/organizations/{ID}",
                            Value = "/organizations/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = true, Required = true}
                            }
                        }
                    }
                },
                //OutOfRouteWebService.svc
                new Request()
                {
                    Name = "/OutOfRouteWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/OORR/",
                            Value = "/OORR/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                                new Parameter() { Name = "FromDate", PreQuery = false},
                                new Parameter() { Name = "ToDate", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "Recurse", PreQuery = false}
                            }
                        },
                    }
                },
                //PlanVsActualWebService.svc
                new Request()
                {
                    Name = "/PlanVsActualWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/PVAR/",
                            Value = "/PVAR/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                                new Parameter() { Name = "FromDate", PreQuery = false},
                                new Parameter() { Name = "ToDate", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "Recurse", PreQuery = false}
                            }
                        },
                        new UriOption()
                        {
                            Name = "/PVAVLSR/",
                            Value = "/PVAVLSR/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                                new Parameter() { Name = "FromDate", PreQuery = false},
                                new Parameter() { Name = "ToDate", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "Recurse", PreQuery = false}
                            }
                        }
                    }
                },
                //ResourceGroupWebService.svc
                new Request()
                {
                    Name = "/ResourceGroupWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/resourcegroup/{ResourceGroupId}",
                            Value = "/resourcegroup/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "ResourceGroupId", PreQuery = true, Required = true},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/resourcegroups/",
                            Value = "/resourcegroups/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationSID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupSID", PreQuery = false},
                                new Parameter() { Name = "IsActive", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "Recurse", PreQuery = false},
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false}
                            }
                        },
                        new UriOption()
                        {
                            Name = "/resourcegroup/{ResourceGroupSid}",
                            Value = "/resourcegroup/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "ResourceGroupSid", PreQuery = true, Required = true},
                            }
                        },

                    }
                },
                //RouteStatusWebService.svc
                new Request()
                {
                    Name = "/RouteStatusWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/RSTR/",
                            Value = "/RSTR/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                                new Parameter() { Name = "FromDate", PreQuery = false},
                                new Parameter() { Name = "ToDate", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "Recurse", PreQuery = false},
                            }
                        },
                    }
                },
                //TODO: Update UriOption/Database to account for Uris that have dual segments: /messsages/{MESSAGESID}/attachment/{ImageSID}
                //RouteWebService.svc
                new Request()
                {
                    Name = "/RouteWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/route",
                            Value = "/route",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "organizationID", PreQuery = false},
                                new Parameter() { Name = "resourceGroupID", PreQuery = false},
                                new Parameter() { Name = "asOfDateTime", PreQuery = false},
                                new Parameter() { Name = "limit", PreQuery = false},
                                new Parameter() { Name = "offset", PreQuery = false},
                                new Parameter() { Name = "recurse", PreQuery = false}
                            }
                        }
                        //TODO: Update UriOption
                        //new UriOption()
                        //{
                        //    Name = "/route/{organizationID}/{routeID}",
                        //    Value = "/route/{organizationID}/{routeID}",
                        //    ThereIsQuery = false,
                        //    Parameters = new List<Parameter>
                        //    {
                        //        new Parameter() { Name = "organizationID", PreQuery = false},
                        //        new Parameter() { Name = "resourceGroupID", PreQuery = false},
                        //        new Parameter() { Name = "asOfDateTime", PreQuery = false},
                        //        new Parameter() { Name = "limit", PreQuery = false},
                        //        new Parameter() { Name = "offset", PreQuery = false},
                        //        new Parameter() { Name = "recurse", PreQuery = false}
                        //    }
                        //},

                    }
                },
                //SiteActivityWebService.svc
                new Request()
                {
                    Name = "/SiteActivityWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/SITR/",
                            Value = "/SITR/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                                new Parameter() { Name = "FromDate", PreQuery = false},
                                new Parameter() { Name = "ToDate", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "Recurse", PreQuery = false}
                            }
                        }
                        //TODO: Update UriOption
                        //new UriOption()
                        //{
                        //    Name = "/route/{organizationID}/{routeID}",
                        //    Value = "/route/{organizationID}/{routeID}",
                        //    ThereIsQuery = false,
                        //    Parameters = new List<Parameter>
                        //    {
                        //        new Parameter() { Name = "organizationID", PreQuery = false},
                        //        new Parameter() { Name = "resourceGroupID", PreQuery = false},
                        //        new Parameter() { Name = "asOfDateTime", PreQuery = false},
                        //        new Parameter() { Name = "limit", PreQuery = false},
                        //        new Parameter() { Name = "offset", PreQuery = false},
                        //        new Parameter() { Name = "recurse", PreQuery = false}
                        //    }
                        //},

                    }
                },
                //SiteWebService.svc
                new Request()
                {
                    Name = "/SiteWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/sites/",
                            Value = "/sites/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "Recurse", PreQuery = false}
                            }
                        },
                        new UriOption()
                        {
                            Name = "/sites/{SiteID}",
                            Value = "/sites/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "SiteID", PreQuery = true, Required = true}
                            }
                        }
                    }
                },
                //TrailerWebService.svc
                new Request()
                {
                    Name = "/TrailerWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/trailer/{trailerID}",
                            Value = "/trailer/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "TrailerID", PreQuery = true, Required = true},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/trailers",
                            Value = "/trailers",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                                new Parameter() { Name = "Status", PreQuery = false},
                                new Parameter() { Name = "asOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "Recurse", PreQuery = false},
                            }
                        }
                    }
                },
                //TripWebService.svc
                new Request()
                {
                    Name = "/TripWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/trip",
                            Value = "/trip",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                                new Parameter() { Name = "RouteID", PreQuery = false},
                                new Parameter() { Name = "TripID", PreQuery = false},
                                new Parameter() { Name = "asOfDateTime", PreQuery = false},
                                new Parameter() { Name = "FromDateTime", PreQuery = false},
                                new Parameter() { Name = "ToDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "Recurse", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/tripV2",
                            Value = "/tripV2",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                                new Parameter() { Name = "RouteID", PreQuery = false},
                                new Parameter() { Name = "TripID", PreQuery = false},
                                new Parameter() { Name = "asOfDateTime", PreQuery = false},
                                new Parameter() { Name = "FromDateTime", PreQuery = false},
                                new Parameter() { Name = "ToDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "TripStatus", PreQuery = false},
                                new Parameter() { Name = "StopStatus", PreQuery = false},
                                new Parameter() { Name = "ChangesOnly", PreQuery = false},
                                new Parameter() { Name = "Recurse", PreQuery = false},
                            }
                        }
                    }
                },
                //UserWebService.svc
                new Request()
                {
                    Name = "/UserWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/users/",
                            Value = "/users/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false},
                                new Parameter() { Name = "IsActive", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/users/{UserID}",
                            Value = "/users/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "UserID", PreQuery = true, Required = false},
                            }
                        }
                    }
                },
                //VehicleBreadcrumbWebService.svc
                new Request()
                {
                    Name = "/VehicleBreadcrumbWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/vehiclebreadcrumb/",
                            Value = "/vehiclebreadcrumb/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false },
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false },
                                new Parameter() { Name = "IsActive", PreQuery = false },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                                new Parameter() { Name = "StartDateTime", PreQuery = false },
                                new Parameter() { Name = "EndDateTime", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false },
                                new Parameter() { Name = "Offset", PreQuery = false },
                                new Parameter() { Name = "OrganizationSID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupSID", PreQuery = false},

                            }
                        },
                        new UriOption()
                        {
                            Name = "/vehiclebreadcrumbs/{VehicleID}",
                            Value = "/vehiclebreadcrumbs/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = true, Required = true},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "StartDateTime", PreQuery = false },
                                new Parameter() { Name = "EndDateTime", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},


                            }
                        },
                        new UriOption()
                        {
                            Name = "/vehiclebreadcrumb/{VehicleSID}",
                            Value = "/vehiclebreadcrumb/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "VehicleSID", PreQuery = true, Required = true},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "StartDateTime", PreQuery = false },
                                new Parameter() { Name = "EndDateTime", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},


                            }
                        },

                    }
                },
                //VehicleStatusWebService.svc
                new Request()
                {
                    Name = "/VehicleStatusWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/vehiclestate/{VehicleID}",
                            Value = "/vehiclestate/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = true, Required = true },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false }
                            }
                        },
                        new UriOption()
                        {
                            Name = "/vehiclestatus/",
                            Value = "/vehiclestatus/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "OrganizationSID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupSID", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "OrganizationID", PreQuery = false },
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false },
                            }
                        },
                        new UriOption()
                        {
                            Name = "/vehiclestatus/{VehicleSID}",
                            Value = "/vehiclestatus/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "VehicleSID", PreQuery = true, Required = true},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                            }
                        },

                    }
                },
                //VehicleWebService.svc
                new Request()
                {
                    Name = "/VehicleWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/vehicle/{VehicleID}",
                            Value = "/vehicle/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = true, Required = true },
                            }
                        },
                        new UriOption()
                        {
                            Name = "/vehicles/",
                            Value = "/vehicles/",
                            ThereIsQuery = true,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "OrganizationSID", PreQuery = false},
                                new Parameter() { Name = "ResourceGroupSID", PreQuery = false},
                                new Parameter() { Name = "IsActive", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                                new Parameter() { Name = "OrganizationID", PreQuery = false },
                                new Parameter() { Name = "ResourceGroupID", PreQuery = false },
                            }
                        },
                        new UriOption()
                        {
                            Name = "/vehicles/{VehicleSID}",
                            Value = "/vehicles/",
                            ThereIsQuery = false,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "VehicleSID", PreQuery = true, Required = true},
                            }
                        },

                    }
                }
            };
            _allRequests = requests;
            //foreach (var request in requests)
            //{
            //    AddCompleteRequest(request);
            //}

        }

        #endregion


        #region Add Record Methods

        public void AddCompleteRequest(Request newRequest)
        {
            long requestID;
            const string insertSql = "INSERT INTO Request (RequestID, Name) VALUES (NULL, @RequestName);";

            using (var connection = SimpleDbConnection())
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@RequestName", newRequest.Name);

                connection.Execute(insertSql, parameters);
                requestID = connection.LastInsertRowId;

                connection.Close();
            }
            AddUriOption(requestID, newRequest.UriOptions);
        }

        private void AddUriOption(long requestID, List<UriOption> uriOptions)
        {
            long uriOptionId;
            const string insertSql = "INSERT INTO UriOption (UriOptionID, Name, Value, ThereIsQuery, RequestID) VALUES (NULL, @Name, @Value, @ThereIsQuery, @RequestID); SELECT last_insert_rowid();";

            foreach (var uri in uriOptions)
            {
                using (var connection = SimpleDbConnection())
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@Name", uri.Name);
                    parameters.Add("@Value", uri.Value);
                    parameters.Add("@ThereIsQuery", uri.ThereIsQuery);
                    parameters.Add("@RequestID", requestID);
                    connection.Execute(insertSql, parameters);
                    uriOptionId = connection.LastInsertRowId;

                    connection.Close();
                }
                AddParameters(uriOptionId, uri.Parameters);

            }

        }

        private void AddParameters(long uriOptionID, List<Parameter> newParameters)
        {
            const string insertSQL = "INSERT INTO Parameter (Name, PreQuery, Required, UriOptionID) VALUES (@Name, @PreQUery, @Required, @UriOption)";
            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                foreach (var param in newParameters)
                {
                    var sqlParameter = new DynamicParameters();
                    sqlParameter.Add("@Name", param.Name);
                    sqlParameter.Add("@PreQuery", param.PreQuery);
                    sqlParameter.Add("@Required", param.Required);
                    sqlParameter.Add("@UriOption", uriOptionID);

                    connection.Execute(insertSQL, sqlParameter);
                }

                connection.Close();
            }
        }

        #endregion


        #region GET Record Methods

        public List<Request> GetAllRequestsWithUriOptionsAndParameters()
        {
            //if (!File.Exists(DbFile))
            //{
            //    CreateDatabaseTables();
            //    LoadData();
            //}

            //var allRequests = GetAllRequests();
            //foreach (var request in allRequests)
            //{
            //    request.UriOptions = GetUriOptions(request.RequestID);
            //    foreach (var uriOption in request.UriOptions)
            //    {
            //        uriOption.Parameters = GetParameters(uriOption.UriOptionID);
            //    }
            //}

            return _allRequests;

        }

        private List<Parameter> GetParameters(int uriOptionID)
        {
            var parameters = new List<Parameter>();
            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                var dynParameters = new DynamicParameters();
                dynParameters.Add("@UriOptionID", uriOptionID);

                parameters = connection.Query<Parameter>("SELECT * FROM Parameter WHERE UriOptionID = @UriOptionID", dynParameters).ToList();
                connection.Close();
            }

            return parameters;
        }

        private List<UriOption> GetUriOptions(int requestId)
        {
            var uriOptions = new List<UriOption>();
            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@RequestID", requestId);

                uriOptions = connection.Query<UriOption>("SELECT * FROM UriOption WHERE RequestID = @RequestID ", parameters).ToList();
                connection.Close();
            }

            return uriOptions;
        }

        private List<Request> GetAllRequests()
        {
            var requests = new List<Request>();
            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                requests = connection.Query<Request>("SELECT * FROM Request").ToList();
                connection.Close();
            }

            return requests;

        }

        #endregion




    }
}
            

