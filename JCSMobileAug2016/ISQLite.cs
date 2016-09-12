using System;
using SQLite.Net;
namespace JCSMobileAug2016
{
	public interface ISQLite
	{

		SQLiteConnection GetConnection();


	}
}

