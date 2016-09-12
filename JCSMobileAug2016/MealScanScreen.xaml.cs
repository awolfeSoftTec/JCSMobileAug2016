using System;
using Xamarin.Forms;
using ZXing;
namespace JCSMobileAug2016
{
	public partial class MealScanScreen : ContentPage
	{



		public MealScanScreen()
		{
			InitializeComponent();
		}

		async void launchScanner(object s, EventArgs args)
		{
			var scanPage =  new ZXing.Net.Mobile.Forms.ZXingScannerPage();
			await Navigation.PushAsync(scanPage);
			//var scanner = new MobileBarcodeScanner();
			//var result = scanner.Scan();

		}


	}
}

