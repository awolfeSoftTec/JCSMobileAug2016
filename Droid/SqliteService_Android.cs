using JCSMobileAug2016.Droid;
using System.IO;
using Xamarin.Forms;
using SQLite;
[assembly: Dependency(typeof(SqliteService_Android))]
namespace JCSMobileAug2016.Droid
{
    public class SqliteService_Android : ISQLite
    {
        //public SqliteService() { }

        #region ISQLite implementation
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SQLiteEx.db3";
            /*
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            Console.WriteLine(path);
            if (!File.Exists(path)) File.Create(path);
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            // Return the database connection 
            return conn;
            */

            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), sqliteFilename);
            return new SQLiteConnection(path);



        }

        #endregion


    }
}