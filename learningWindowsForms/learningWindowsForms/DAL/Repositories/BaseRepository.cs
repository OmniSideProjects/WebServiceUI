using System;
using System.Data.SQLite;

namespace learningWindowsForms.DAL.Repositories
{
     public class BaseRepository
    {
        public static string DbFile
        {
            get { return Environment.CurrentDirectory + "\\SimpleDb.sqlite"; }
        }

        public static SQLiteConnection SimpleDbConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFile);
        }

    }
}
