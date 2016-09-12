using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JCSMobileAug2016
{
	public partial class MedicineRefusedPage : ContentPage
	{
		public MedicineRefusedPage()
		{
			InitializeComponent();
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

	}
}

