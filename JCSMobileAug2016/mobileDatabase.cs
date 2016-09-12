using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;


namespace JCSMobileAug2016
{
	public class mobileDatabase
	{
		SQLiteConnection _connection;

		public mobileDatabase()
		{
		//	public static SQLiteConnection _connection;
			_connection = DependencyService.Get<ISQLite>().GetConnection();
			_connection.CreateTable<Unit>();
			//_connection.CreateTable<Detainee>();
			//create some units

			//detainees for unitA
			Detainee[] listA = new Detainee[] { (new Detainee("Henry Johnson", 2, "UnitA")),
				(new Detainee("Arthur Wallace", 2, "UnitA")), (new Detainee("Shelly Cooper", 2, "UnitA"))  };

			Unit unitA = new Unit(2, "UnitA", listA);

			//detainees for unitB
			Detainee[] listB = new Detainee[] { (new Detainee("Amber Johnson", 2, "UnitB")),
				(new Detainee("Rasheed Wallace", 2, "UnitB")), (new Detainee("D.B. Cooper", 2, "UnitB"))  };

			Unit unitB = new Unit(2, "UnitB", listB);

			//detainees for unitC
			Detainee[] listC = new Detainee[] { (new Detainee("Andrew Johnson", 2, "UnitC")),
				(new Detainee("Michael Wallace", 2, "UnitC")), (new Detainee("Anthony Cooper", 2, "UnitC"))  };

			Unit unitC = new Unit(2, "UnitB", listC);



			//insert the units into the local SQLite unit table

			_connection.Insert(unitA);
			_connection.Insert(unitB);
			_connection.Insert(unitC);


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

