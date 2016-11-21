using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace JCSMobileAug2016
{
	public partial class MealCheckScreen : ContentPage
	{
		public static string selectedItem;
		//public MealTypeService mealService = new MealTypeService();
		//public List<MealType> listOfMealTypes;

		public MealCheckScreen()
		{
			 
			InitializeComponent();
			//run the method to query db and populate mealTypes
			RefreshData();

         

        }

		//this method is for actually pulling down the MealType data
		public void RefreshData()
		{
			//add mealTypes from the App class to the picker
				for (int i = 0; i < App.listOfMealTypes.Count; i++)
				{
					mealPicker.Items.Add(App.listOfMealTypes[i].description);
				}


		}


		//function that handles what happens when an item is selected
        void handleChangedIndex(object s, EventArgs args)
		{

			selectedItem = App.listOfMealTypes[mealPicker.SelectedIndex].description;


		}



        //function that handles what happens when the cancel button is selected
        void cancelBtnClicked(object s, EventArgs args)
		{
			
			Navigation.PopAsync();//go back to the previous page


		}



		//function that handles what happens when the continue button is selected
		void continueBtnClicked(object s, EventArgs args)
		{
			if (selectedItem != null)
			{
				Navigation.PushAsync(new MealScanScreen());
			}
			else
			{
				DisplayAlert("Alert", "Please Select Meal Type!", "OK");
			}
		}


	}
}

