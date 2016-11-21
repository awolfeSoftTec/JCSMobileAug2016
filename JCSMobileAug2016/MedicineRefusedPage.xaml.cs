using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;



using Xamarin.Forms;

namespace JCSMobileAug2016
{
	public partial class MedicineRefusedPage : ContentPage
	{
		
		public MedicineRefusedPage()
		{
			InitializeComponent();
			//populate potential reasons
			populateReasons();
		}

		//handles incrementing the first stepper
		public void handleIncrement(object s, EventArgs args)
		{
			lblStep.Text = stepper.Value.ToString();


		}

		//handles incrementing the second stepper
		public void handleIncrement2(object s, EventArgs args)
		{
			lblStep2.Text = stepper2.Value.ToString();


		}

		public void populateReasons()
		{
			
			for (int i = 0; i < App.listOfReasonsRefused.Count; i++)
			{
				reason1Picker.Items.Add(App.listOfReasonsRefused[i].description);
				reason2Picker.Items.Add(App.listOfReasonsRefused[i].description);
			}

		

		}

	}
}

