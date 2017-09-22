using learningWindowsForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningWindowsForms.Interfaces
{
    public interface IRequestRepo
    {
        void RemoveOldFile();
        void CreateDatabaseTables();
        List<Request> GetAllRequestsWithUriOptionsAndParameters();
        void AddCompleteRequest(Request newRequest);
    }
}
