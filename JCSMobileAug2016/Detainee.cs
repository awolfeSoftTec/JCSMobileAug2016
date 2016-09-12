using System;
using SQLite.Net.Attributes;
namespace JCSMobileAug2016
{
	public class Detainee
	{

		[PrimaryKey, AutoIncrement]
		public int detaineeID { get; set; }
		public string detaineeName { get; set;}
		public int facilityID { get; set; }
		public string unitName { get; set; }




		public Detainee()
		{
		}

		public Detainee(string dName, int fID, string unitName)
		{
			this.detaineeName = dName;
			this.facilityID = fID;
			this.unitName = unitName;


		}
	}
}

