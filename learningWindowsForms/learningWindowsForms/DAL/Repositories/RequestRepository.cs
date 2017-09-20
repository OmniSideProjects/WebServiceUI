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
        public RequestRepository()
        {
                RemoveOldFile();
                CreateDatabaseTables();
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
                                IsThereQuery    boolean NOT NULL,
                                RequestID       INTEGER NOT NULL,
                                FOREIGN KEY     (RequestID) REFERENCES Request(RequestID)
                            );
                            CREATE TABLE Parameter
                            (
                                ParameterID     INTEGER PRIMARY KEY,
                                Name            varchar(30) NOT NULL,
                                PreQuery        boolean NOT NULL,
                                UriOptionID     INTEGER NOT NULL,
                                FOREIGN KEY     (UriOptionID) REFERENCES UriOption(UriOptionID)
                            );");
            }
        }

        private void LoadData()
        {

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
                            IsThereQuery = true,
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "DriverID", PreQuery = true},
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
                            IsThereQuery = true,
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
                            IsThereQuery = true,
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
                            IsThereQuery = true,
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
                            IsThereQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "PHONENUMBER", PreQuery = true },
                            }
                        },
                        new UriOption()
                        {
                            Name = "/devices/",
                            Value = "/devices/",
                            IsThereQuery = true,
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationID", PreQuery = false },
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", PreQuery = true },
                                new Parameter() { Name = "Edits", PreQuery = false },
                                new Parameter() { Name = "StartDate", PreQuery = false },
                                new Parameter() { Name = "EndDate", PreQuery = false },
                            }
                        },
                        new UriOption()
                        {
                            Name = "/driverlogdetails/",
                            Value = "/driverlogdetails/",
                            IsThereQuery = true,
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", PreQuery = true },
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", PreQuery = true },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
                            }
                        },
                        new UriOption()
                        {
                            Name = "/driverstatus/",
                            Value = "/driverstatus/",
                            IsThereQuery = true,
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverSID", PreQuery = true },
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false },
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
                            IsThereQuery = true,
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
                            IsThereQuery = true,
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
                            IsThereQuery = true,
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
                            IsThereQuery = true,
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = true},
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
                            IsThereQuery = true,
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
                            IsThereQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "FormTemplateCategorySID", PreQuery = true},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/formcategory/{FormTemplateCategoryID}",
                            Value = "/formcategory/",
                            IsThereQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "FormTemplateCategoryID", PreQuery = true},
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
                            IsThereQuery = true,
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
                            IsThereQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "FormNumber", PreQuery = true},
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
                            IsThereQuery = true,
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
                            IsThereQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "FormNumber", PreQuery = true},
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
                            IsThereQuery = true,
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = true},
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationId", PreQuery = true},
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleId", PreQuery = true},
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "OrganizationId", PreQuery = true},
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "VehicleId", PreQuery = true},
                                new Parameter() { Name = "StartDateTime", PreQuery = false},
                                new Parameter() { Name = "EndDateTime", PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},
                            }
                        },
                    }
                },
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
                            IsThereQuery = true,
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "MessageSID", PreQuery = true},
                                new Parameter() { Name = "IncludeImageData", PreQuery = false},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/messages/read",
                            Value = "/messages/read",
                            IsThereQuery = true,
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
                            IsThereQuery = true,
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
                            IsThereQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "MessageSID", PreQuery = true},
                            }
                        },
                        new UriOption()
                        {
                            Name = "/messages/update/{MessageSID}",
                            Value = "/messages/update/",
                            IsThereQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "MessageSID", PreQuery = true},
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
                            IsThereQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", PreQuery = false}
                            }
                        },
                        new UriOption()
                        {
                            Name = "/drivers/",
                            Value = "/drivers/",
                            IsThereQuery = true,
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
                            IsThereQuery = false,
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverSID", PreQuery = true}
                            }
                        },


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
                            IsThereQuery = true,
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "VehicleID", PreQuery = true},
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
                            IsThereQuery = true,
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "VehicleSID", PreQuery = true},
                                new Parameter() { Name = "AsOfDateTime", PreQuery = false},
                                new Parameter() { Name = "StartDateTime", PreQuery = false },
                                new Parameter() { Name = "EndDateTime", PreQuery = false },
                                new Parameter() { Name = "Limit", PreQuery = false},
                                new Parameter() { Name = "Offset", PreQuery = false},


                            }
                        },

                    }
                },
            };

            foreach (var request in requests)
            {
                AddCompleteRequest(request);
            }

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
            const string insertSql = "INSERT INTO UriOption (UriOptionID, Name, Value, IsThereQuery, RequestID) VALUES (NULL, @Name, @Value, @IsThereQuery, @RequestID); SELECT last_insert_rowid();";

            foreach (var uri in uriOptions)
            {
                using (var connection = SimpleDbConnection())
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@Name", uri.Name);
                    parameters.Add("@Value", uri.Value);
                    parameters.Add("@IsThereQuery", uri.IsThereQuery);
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
            const string insertSQL = "INSERT INTO Parameter (Name, PreQuery, UriOptionID) VALUES (@Name, @PreQUery, @UriOption)";
            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                foreach (var param in newParameters)
                {
                    var sqlParameter = new DynamicParameters();
                    sqlParameter.Add("@Name", param.Name);
                    sqlParameter.Add("@PreQuery", param.PreQuery);
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
            if (!File.Exists(DbFile))
            {
                CreateDatabaseTables();
                LoadData();
            }

            var allRequests = GetAllRequests();
            foreach (var request in allRequests)
            {
                request.UriOptions = GetUriOptions(request.RequestID);
                foreach (var uriOption in request.UriOptions)
                {
                    uriOption.Parameters = GetParameters(uriOption.UriOptionID);
                }
            }

            return allRequests;

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
            

