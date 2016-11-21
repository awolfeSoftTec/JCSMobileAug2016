using System;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;
using ZXing;
using Xamarin.Forms;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace JCSMobileAug2016
{
	public partial class App : Xamarin.Forms.Application
	{
		//variables that will be used throughout
		public static List<MealType> listOfMealTypes { get; set; }
		public static List<MedicationType> listOfMedications { get; set; }
		public static List<ObservationType> listOfObservationTypes { get; set; }
		public static List<Juvenile> listOfJuveniles { get; set; }
		public static List<Juvenile> juvenilesInRoom { get; set; }
		public static List<Room> listOfRooms { get; set; }
		public static List<ReasonRefused> listOfReasonsRefused { get; set; }
		public static string selectedRoomName { get; set; }
		public static RoomCheckRecord roomRecord { get; set; }


        public App()
        {

            MainPage = new NavigationPage(new JCSMobileAug2016Page());
        }



    
    

		protected override void OnStart()
		{
			// Handle when your app starts
			getFromDB();


		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		//get all of the necessary variables
		public void getFromDB()
		{
			//preload all of items that we will need from the database to prevent
			//anywhere else besides on load
			getObservationTypes();
			getJuveniles();
			getRooms();
			getMealTypes();
			getMedicationTypes();
			getReasonsRefused();
		}

		//get reasonsRefused
		async void getReasonsRefused()
		{

			// initialize the client
			HttpClient client = new HttpClient();

			//make call to the web service and convert GET request to a list
			//of Medication Types
			try
			{
				var uri = new Uri(string.Format("http://vtestweb-01.proware.com/jcsAPI/api/reasonRefused", string.Empty));
				var response = await client.GetAsync(uri);
				//see what we get and if it we have something that we can use 
				if (response.IsSuccessStatusCode)
				{
					//then break up what we got back into ReasonRefused objects
					var content =  await response.Content.ReadAsStringAsync();
					listOfReasonsRefused = JsonConvert.DeserializeObject<List<ReasonRefused>>(content);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"					ERROR{0}", ex.Message);

			}


		}



		//get medications
		async void getMedicationTypes()
		{
			//initialize the client
			HttpClient client = new HttpClient();

			//make call to the web service and convert GET request to a list
			//of Medication Types
			try
			{
				var uri = new Uri(string.Format("http://vtestweb-01.proware.com/jcsAPI/api/medicationType", string.Empty));
				var response = await client.GetAsync(uri);

				//see what we g
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					listOfMedications = JsonConvert.DeserializeObject<List<MedicationType>>(content);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"					ERROR{0}", ex.Message);

			}


		}
		//get mealTypes
		async void getMealTypes()
		{
			HttpClient client = new HttpClient();

			try
			{
				var uri = new Uri(string.Format("http://vtestweb-01.proware.com/jcsAPI/api/mealType", string.Empty));
				var response = await client.GetAsync(uri);

				//see what we go
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					listOfMealTypes = JsonConvert.DeserializeObject<List<MealType>>(content);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"					ERROR{0}", ex.Message);

			}


		}



		//get observationTypes
		async void getObservationTypes()
		{
			HttpClient client = new HttpClient();

			try
			{
				var uri = new Uri(string.Format("http://vtestweb-01.proware.com/jcsAPI/api/observationType", string.Empty));
				var response = await client.GetAsync(uri);

				//see what we got
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					listOfObservationTypes = JsonConvert.DeserializeObject<List<ObservationType>>(content);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"					ERROR{0}", ex.Message);

			}


		}
		//get juveniles
		async void getJuveniles()
		{
			HttpClient client = new HttpClient();


			try
			{
				var uri = new Uri(string.Format("http://vtestweb-01.proware.com/jcsAPI/api/juvenile", string.Empty));
				var response = await client.GetAsync(uri);

				//see what we got
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					listOfJuveniles = JsonConvert.DeserializeObject<List<Juvenile>>(content);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"					ERROR{0}", ex.Message);

			}


		}
		//get rooms
		async void getRooms()
		{
			HttpClient client = new HttpClient();


			try
			{
				var uri = new Uri(string.Format("http://vtestweb-01.proware.com/jcsAPI/api/Room", string.Empty));
				var response = await client.GetAsync(uri);

				//see what we got
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					listOfRooms = JsonConvert.DeserializeObject<List<Room>>(content);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"					ERROR{0}", ex.Message);

			}


		}




	}
}

