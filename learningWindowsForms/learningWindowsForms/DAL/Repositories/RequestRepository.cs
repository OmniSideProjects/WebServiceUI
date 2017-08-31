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

namespace learningWindowsForms.DAL.Repositories
{
    public class RequestRepository : BaseRepository
    {
        public RequestRepository()
        {
                RemoveOldFile();
                CreateDatabaseTables();
                LoadData();
        }

        #region Initialize Database

        private void RemoveOldFile()
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

        private void CreateDatabaseTables()
        {
            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                connection.Execute(
                           @"CREATE TABLE Request
                            (
                                RequestID       INTEGER PRIMARY KEY,
                                Name            varchar(30) NOT NULL
                            );
                            CREATE TABLE UriOption
                            (
                                UriOptionID     INTEGER PRIMARY KEY,
                                Name            varchar(30) NOT NULL,
                                RequestID       INTEGER NOT NULL,
                                FOREIGN KEY     (RequestID) REFERENCES Request(RequestID)
                            );
                            CREATE TABLE Parameter
                            (
                                ParameterID     INTEGER PRIMARY KEY,
                                Name            varchar(30) NOT NULL,
                                IsRequired      boolean NOT NULL,
                                IsThereQuery    boolean NOT NULL,
                                PreQuery        boolean NOT NULL,
                                UriOptionID     INTEGER NOT NULL,
                                FOREIGN KEY     (UriOptionID) REFERENCES UriOption(UriOptionID)
                            );"
                //INSERT INTO Request (RequestID, Name) 
                //VALUES(1, '/DriverWebService.svc');

                //INSERT INTO UriOption(UriOptionID, Name, RequestID)
                //VALUES(1, '/driver/', 1),
                //       (2, '/drivers/', 1);

                //INSERT INTO Parameter(ParameterID, Name, UriOptionID, IsRequired, IsThereQuery, PreQuery)
                //VALUES(1, 'DriverID', 1, 1, 0, 0),
                //       (2, 'OrganizationID', 2, 1, 1, 0),
                //       (3, 'ResourceGroupID', 2, 0, 1, 0); 
                                    );

            }
        }

        private void LoadData()
        {

            List<Request> requests = new List<Request>()
            {
                new Request()
                {
                    Name = "/DriverWebService.svc",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/driver/",
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", IsRequired = true, IsThereQuery = false, PreQuery = false}
                            }
                        },

                        new UriOption()
                        {
                            Name = "/drivers/",
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "ResourceGroupSID", IsRequired = false, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "OrganizationSID", IsRequired = false, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "IsActive", IsRequired = false, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", IsRequired = false, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "Limit", IsRequired = false, IsThereQuery = false, PreQuery = false},
                                new Parameter() { Name = "Offset", IsRequired = false, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "OrganizationID", IsRequired = true, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", IsRequired = false, IsThereQuery = true, PreQuery = false},


                            }
                        }
                    }


                },
                new Request()
                {
                    Name = "/TestInsert",
                    UriOptions = new List<UriOption>()
                    {
                        new UriOption()
                        {
                            Name = "/driver/",
                            Parameters = new List<Parameter>
                            {
                                new Parameter() { Name = "DriverID", IsRequired = true, IsThereQuery = false, PreQuery = false}
                            }
                        },

                        new UriOption()
                        {
                            Name = "/drivers/",
                            Parameters = new List<Parameter>()
                            {
                                new Parameter() { Name = "ResourceGroupSID", IsRequired = false, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "OrganizationSID", IsRequired = false, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "IsActive", IsRequired = false, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "AsOfDateTime", IsRequired = false, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "Limit", IsRequired = false, IsThereQuery = false, PreQuery = false},
                                new Parameter() { Name = "Offset", IsRequired = false, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "OrganizationID", IsRequired = true, IsThereQuery = true, PreQuery = false},
                                new Parameter() { Name = "ResourceGroupID", IsRequired = false, IsThereQuery = true, PreQuery = false},


                            }
                        }
                    }


                },            };

            foreach (var request in requests)
            {
                AddCompleteRequest(request);
            }

        }

        #endregion


        #region Create Record Methods

        private void AddCompleteRequest(Request newRequest)
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
            const string insertSql = "INSERT INTO UriOption (UriOptionID, Name, RequestID) VALUES (NULL, @Name, @RequestID); SELECT last_insert_rowid();";

            foreach (var uri in uriOptions)
            {
                using (var connection = SimpleDbConnection())
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@Name", uri.Name);
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
            const string insertSQL = "INSERT INTO Parameter (Name, IsRequired, IsThereQuery, PreQuery, UriOptionID) VALUES (@Name, @IsRequired, @IsThereQuery, @PreQUery, @UriOption)";
            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                foreach (var param in newParameters)
                {
                    var sqlParameter = new DynamicParameters();
                    sqlParameter.Add("@Name", param.Name);
                    sqlParameter.Add("@IsRequired", param.IsRequired);
                    sqlParameter.Add("@IsThereQuery", param.IsThereQuery);
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
            

