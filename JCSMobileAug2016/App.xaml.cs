using Xamarin.Forms;
namespace JCSMobileAug2016
{
    public partial class App : Xamarin.Forms.Application
    {
        static mobileDatabase dbUtils;
        public App()
        {

            MainPage = new NavigationPage(new JCSMobileAug2016Page());
        }


        public static mobileDatabase DAUtil
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new mobileDatabase();
                }
                return dbUtils;
            }
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

