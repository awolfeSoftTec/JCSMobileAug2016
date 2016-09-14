using System;
using SQLite;
namespace JCSMobileAug2016
{
	public class Unit
	{
		[PrimaryKey, AutoIncrement]
		public int unitID { get; set; }
		public int facilityID { get; set; }
		public string unitName { get; set; }
		public Detainee[] detaineeList { get; set; }
		//list of detainees


            

		public Unit()
		{
			//default constructor
		}


		public Unit(int fID, string uName, Detainee[] dList)
		{
			//parameterized constructor

			//this.unitID = uID;
			this.facilityID = fID;
			this.unitName = uName;
			this.detaineeList = dList;

		}

    

	}
}

