using System;
using System.IO;
using System.Data.SQLite;

namespace learningWindowsForms.DAL.Repositories
{
     public class BaseRepository
    {
        public static string DbFile
        {
            get {
                    return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"WebServiceUI", "Database.sqlite"); }
                }

        public static SQLiteConnection SimpleDbConnection()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WebServiceUI");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WebServiceUI"));
            }

            return new SQLiteConnection("Data Source=" + DbFile);
        }

    }
}
