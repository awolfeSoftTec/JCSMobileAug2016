using System;
namespace JCSMobileAug2016
{
	public interface ISQLite
	{
        
        SQLite.SQLiteConnection GetConnection();
        
	}
}

