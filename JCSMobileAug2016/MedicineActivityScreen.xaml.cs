using System;
using System.Collections.Generic;
using ZXing;
using Xamarin.Forms;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;

namespace JCSMobileAug2016
{
	public partial class MedicineActivityScreen : ContentPage
	{
		//list of variables to be used on this page
		//public List<MedicationType> listOfMedications { get; set; }


		public MedicineActivityScreen()
		{
			InitializeComponent();
			loadMedicationTypes();
		}

		//launches the scanner
		async void launchScanner(object s, EventArgs args)
		{
			var scanPage = new ZXing.Net.Mobile.Forms.ZXingScannerPage();
			await Navigation.PushAsync(scanPage);
			//var scanner = new MobileBarcodeScanner();
			//var result = scanner.Scan();

		}

		public void assignDirections(object s, EventArgs args)
		{


			directionsEditor.Text = App.listOfMedications[medicationPicker.SelectedIndex].Instructions;


		}


		public void loadMedicationTypes()
		{
				for (int i = 0; i < App.listOfMedications.Count; i++)
				{
					medicationPicker.Items.Add(App.listOfMedications[i].Medication);
				}
		}


		//shows the desired image at full scale
		async void fullSizeImage(object s, EventArgs args)
		{
			await Navigation.PushAsync(new FullSizeImageView());
		}

		//shows the desired image at full scale
		async void backBtnClicked(object s, EventArgs args)
		{
			await Navigation.PopAsync();
		}


		public void loadJuvenileInformation(object s, EventArgs args)
		{
			lblName.Text = "Frederick Flintstone";
			lblDOB.Text = "DOB: 7/1/1960";
			lblBarcode.Text = "4034";

		}


		async void attemptToSave(object s, EventArgs args)
		{
			//We need to check to see if the medicine was successfully administered

			if (notGivenSwitch.IsToggled == true)
			{
				//then we need to explain why the medicine didn't get administered
				var answer = await DisplayAlert("Medication Actvity", "Medicine was refused?", "Yes", "No");
				if (answer == true)
				{
					//we need to take them to the page where they can explain why the medication 
					//was refused

					await Navigation.PushAsync(new MedicineRefusedPage());
				}
				//if the medicine wasn't refused then just close the dialog box and remain on the page

			}
			else
			{
				//everything should be peachy and we can pop this page off of the stack
				await DisplayAlert("Medicine Activiy", "The Medical Record has been saved.", "Ok");
				await Navigation.PopAsync();

			}



		}


	}
}

