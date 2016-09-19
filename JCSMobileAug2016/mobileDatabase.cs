using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace JCSMobileAug2016
{
	public class mobileDatabase
	{
		private SQLiteConnection _connection;

		public mobileDatabase()
		{
		//	public static SQLiteConnection _connection;
			_connection = DependencyService.Get<ISQLite>().GetConnection();
			_connection.CreateTable<Unit>();
			//_connection.CreateTable<Detainee>();
			

    */
        }


        public IEnumerable<Unit> getUnits()
		{

			return (from t in _connection.Table<Unit>() select t).ToList();

		}

		public IEnumerable<string> getUnitsAsString()
		{

			return (from t in _connection.Table<Unit>()select t.unitName).ToList();

		}

		public Unit getUnit(int id)
		{

			return _connection.Table<Unit>().FirstOrDefault(t => t.unitID == id);

		}

		public IEnumerable<Detainee> getDetainees()
		{

			return (from t in _connection.Table<Detainee>() select t).ToList();

		}

		public interface ISQLite
		{

			SQLiteConnection GetConnection();


		}
	}
}

