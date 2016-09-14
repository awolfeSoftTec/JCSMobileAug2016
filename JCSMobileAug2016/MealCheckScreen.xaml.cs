using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JCSMobileAug2016
{
	public partial class MealCheckScreen : ContentPage
	{
        


		public MealCheckScreen()
		{
			 
			InitializeComponent();
           
            /*
			foreach (var name in App.DAUtil.getUnitsAsString())
			{
				unitPicker.Items.Add(name);

			}
           
           */

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

