using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JCSMobileAug2016
{
	public partial class MealCheckScreen : ContentPage
	{

		public static mobileDatabase conn;



		public MealCheckScreen()
		{
			 
			InitializeComponent();
			conn = new mobileDatabase();
			//this.unitPicker.Items.Add("Austin");
			/*
			foreach (var name in conn.getUnitsAsString())
			{
				unitPicker.Items.Add(name);

			}
			*/

			//unitPicker.Items. = conn.getUnitsAsString();
			unitPicker.Items.Add("UnitA");
			unitPicker.Items.Add("UnitB");
			unitPicker.Items.Add("UnitC");
			unitPicker.Items.Add("UnitD");


		}



		//function that handles what happens when the cancel button is selected
		void cancelBtnClicked(object s, EventArgs args)
		{
			
			Navigation.PopAsync();//go back to the previous page


		}



		//function that handles what happens when the continue button is selected
		void continueBtnClicked(object s, EventArgs args)
		{

			Navigation.PushAsync(new MealScanScreen());


		}


	}
}

