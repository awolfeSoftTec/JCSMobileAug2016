using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JCSMobileAug2016
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}


		//when the RoomCheck button is clicked
		async void roomCheckBtnClicked(object s, EventArgs args)
		{


			//await Navigation.PushAsync(new RoomCheckScreen());
			await Navigation.PushAsync(new RoomCheckScreen());

		}
		//when the MealCheck button is clicked
		async void mealCheckBtnClicked(object s, EventArgs args)
		{


			await Navigation.PushAsync(new MealCheckScreen());

		}
		//when the MedicineActivity button is clicked
		async void medicineActivityBtnClicked(object s, EventArgs args)
		{


			await Navigation.PushAsync(new MedicineActivityScreen());

		}


		//when the logOut button is clicked
		async void logOutBtnClicked(object s, EventArgs args)
		{

			await Navigation.PopAsync();

		}

	}
}

