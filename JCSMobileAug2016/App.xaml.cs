using Xamarin.Forms;
namespace JCSMobileAug2016
{
	public partial class App : Xamarin.Forms.Application
	{
		public App()
		{
			
			MainPage = new NavigationPage(new JCSMobileAug2016Page());
			//MainPage = new JCSMobileAug2016Page();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

