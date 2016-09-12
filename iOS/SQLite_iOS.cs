using System;
using System.IO;
using JCSMobileAug2016;
using JCSMobileAug2016.iOS;
using Xamarin.Forms;
using SQLite.Net;
[assembly: Dependency (typeof (SQLite_iOS))]
namespace JCSMobileAug2016.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS()
		{
		}

		public SQLite.Net.SQLiteConnection GetConnection()
		{

			var sqliteFilename = "JCSMobileAug2016.db3";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//documents folder
			string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);
			// Create the connection
			var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			var conn = new SQLite.Net.SQLiteConnection(platform, path);


			// Return the database connection
			return conn;
		}

		SQLiteConnection ISQLite.GetConnection()
		{
			throw new NotImplementedException();
		}
	}



		}



