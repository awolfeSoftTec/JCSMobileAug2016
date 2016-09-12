using System;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;
using ZXing;
using Xamarin.Forms;

namespace JCSMobileAug2016
{
	public partial class RoomCheckScreen : ContentPage
	{
		public RoomCheckScreen()
		{
			InitializeComponent();
		}

		async void launchScanner(object s, EventArgs args)
		{
			var scanPage = new ZXing.Net.Mobile.Forms.ZXingScannerPage();
			await Navigation.PushAsync(scanPage);
			//var scanner = new MobileBarcodeScanner();
			//var result = scanner.Scan();

		}
	}
}

