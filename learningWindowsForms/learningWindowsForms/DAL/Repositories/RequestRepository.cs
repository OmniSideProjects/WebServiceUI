using System;
using System.IO;
using learningWindowsForms.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace learningWindowsForms.DAL.Repositories
{
    public class RequestRepository : BaseRepository
    {
        public List<Request> GetAllRequestsWithUriOptionsAndParameters()
        {
            if (!File.Exists(DbFile))
            {
                CreateDatabase();
            }

            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                var results = connection.Query<Request>(@"SELECT * FROM Request").ToList();

                foreach (var request in results)
                {
                    request.UriOptions = GetUriOptions(request.RequestID, connection);

                    foreach (var uriOption in request.UriOptions)
                    {
                        uriOption.Parameters = GetParameters(uriOption.UriOptionID, connection).ToList();
                    }
                }

                return results;
            }

        }

        private List<Parameter> GetParameters(int uriOptionID, SQLiteConnection connection)
        {
            var dynParameters = new DynamicParameters();
            dynParameters.Add("@UriOptionID", uriOptionID);
            var parameters = connection.Query<Parameter>("SELECT * FROM Parameter WHERE UriOptionID = @UriOptionID", dynParameters).ToList();

            return parameters;
        }

        private List<UriOption> GetUriOptions(int requestId, SQLiteConnection connection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RequestID", requestId);
            var uriOptions = connection.Query<UriOption>("SELECT * FROM UriOption WHERE RequestID = @RequestID ", parameters).ToList();

            return uriOptions;
        }


        private void CreateDatabase()
        {
            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                connection.Execute(
                           @"CREATE TABLE Request
                            (
                                RequestID       INTEGER NOT NULL,
                                Name            varchar(30) NOT NULL,
                                PRIMARY KEY     (RequestID)
                            );
                            CREATE TABLE UriOption
                            (
                                UriOptionID     INTEGER NOT NULL,
                                Name            varchar(30) NOT NULL,
                                RequestID       INTEGER NOT NULL,
                                PRIMARY KEY     (UriOptionID),
                                FOREIGN KEY     (RequestID) REFERENCES Request(RequestID)
                            );
                            CREATE TABLE Parameter
                            (
                                ParameterID     INTEGER NOT NULL,
                                Name            varchar(30) NOT NULL,
                                IsRequired        boolean NOT NULL,
                                IsThereQuery    boolean NOT NULL,
                                PreQuery        boolean NOT NULL,
                                UriOptionID     INTEGER NOT NULL,
                                PRIMARY KEY     (ParameterID),
                                FOREIGN KEY     (UriOptionID) REFERENCES UriOption(UriOptionID)
                            );

                            INSERT INTO Request (RequestID, Name) 
                            VALUES (1 , '/DriverWebService.svc');
                            
                            INSERT INTO UriOption (UriOptionID, Name, RequestID)
                            VALUES (1, '/driver/', 1),
                                   (2, '/drivers/', 1);

                            INSERT INTO Parameter (ParameterID, Name, UriOptionID, IsRequired, IsThereQuery, PreQuery)
                            VALUES (1, 'DriverID', 1, 1, 0, 0),
                                   (2, 'OrganizationID', 2, 1, 1, 0),
                                   (3, 'ResourceGroupID', 2, 0, 1, 0);"

                    );
            }
        }
    }
}
