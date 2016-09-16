using System;
using System.IO;
using Xamarin.Forms;
using JCSMobileAug2016.iOS;
using SQLite;

[assembly: Dependency(typeof(SqliteService_iOS))]
namespace JCSMobileAug2016.iOS
{
	public class SqliteService_iOS : ISQLite
	{
		
		#region ISQLite implementation
		public SQLiteConnection GetConnection()
		{
			var sqliteFilename = "SQLiteEx.db3";
			

            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, sqliteFilename);
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            return new SQLiteConnection(path);
        }
		#endregion
	}
}

