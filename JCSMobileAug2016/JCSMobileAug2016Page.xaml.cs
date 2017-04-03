using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace JCSMobileAug2016
{
	public partial class JCSMobileAug2016Page : ContentPage
	{
		//Initialize variables

		//Attempt at creating a DB 
		//ar db = new SQLiteConnection(dbPath);


		public JCSMobileAug2016Page()
		{
			InitializeComponent();
			//adding the image to the main screen
            
			logoImage.Source = Device.OnPlatform(
				iOS: ImageSource.FromFile("jcsBadge.gif"),
				Android: ImageSource.FromFile("jcsBadge.gif"),
				WinPhone: ImageSource.FromFile("images/jcsBadge.gif"));
                
		}

			//call when the crentials check out
		 void logInBtnClicked(object s, EventArgs args)
			{
				//need to validate whether credentials match

				//await Navigation.PushAsync(new MainPage());
				//await Navigation.PushAsync(new MainPage());


				if (userEntry.Text == "A4202" && passEntry.Text == "DillyDally")
					 Navigation.PushAsync(new MainPage());
				else
					DisplayAlert("Alert", "Invalid barcode/password combination!\n\nTry Again!", "OK");


			}
//	*/
	}
}

