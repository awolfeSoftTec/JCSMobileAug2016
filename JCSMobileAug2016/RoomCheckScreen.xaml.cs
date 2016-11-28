using System;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;
using ZXing;
using Xamarin.Forms;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;

namespace JCSMobileAug2016
{
	public partial class RoomCheckScreen : ContentPage
	{
		//All of the variables used in this class are static variables from the App class
		public List<Juvenile> juvenilesInRoom { get; set; }
		public RoomCheckScreen()
		{
			InitializeComponent();
			//take from the local db and populate the picker
			loadObservationTypes();
			//get all of the detainees in detention center and load them into list
			loadJuveniles();
			//get list of all the rooms in the facility
			loadRooms();
			//get list of barcodes that we are looking for once they scan

			//need to add method to handle loading detainee picker once the room has been



		}

		async void launchScanner(object s, EventArgs args)
		{
			var scanPage = new ZXing.Net.Mobile.Forms.ZXingScannerPage();
			await Navigation.PushAsync(scanPage);
			//var scanner = new MobileBarcodeScanner();
			//var result = scanner.Scan();

		}

		void handleRoomPOST(object s, EventArgs args)
		{
			//store roomRecord information
			App.roomRecord.roomNum = App.selectedRoomName;
			App.roomRecord.detainee = App.juvenilesInRoom[detaineePicker.SelectedIndex].firstName;
			App.roomRecord.observation = App.listOfObservationTypes[observationPicker.SelectedIndex].description;
			App.roomRecord.notes = notesField.Text;


			//prepare for POST to api
			// initialize the client
			HttpClient client = new HttpClient();

			//make call to the web service and convert GET request to a list
			//of Medication Types
			try
			{
				var uri = new Uri(string.Format("http://vtestweb-01.proware.com/jcsAPI/api/roomcheckrecord", App.roomRecord));
				var json = JsonConvert.SerializeObject(App.roomRecord);
				var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");


				var response = client.PostAsync(uri, content);


			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"					ERROR{0}", ex.Message);

			}
		}


		public void findJuvenile()
		{
			//create new list of juveniles
			for (int i = 0; i < App.listOfJuveniles.Count; i++)
			{
				//check against our list of juveniles to see who is in the 
				//selected room
				if (App.listOfJuveniles[i].roomNumber == App.selectedRoomName)
				{
					//App.juvenilesInRoom.Add(App.listOfJuveniles[i]);
					detaineePicker.Items.Add((App.listOfJuveniles[i].firstName + " " + App.listOfJuveniles[i].lastName));
				}
			}
		}//end findJuvenile



		void handleDetaineePicker(object s, EventArgs args)
		{
			//if there is already detainee(s) in the picker, 
			//then remove them
			detaineePicker.Items.Clear();


			//find out which room was selected
			App.selectedRoomName = App.listOfRooms[roomPicker.SelectedIndex].roomName;
			//go through list of detainees and see who is in that room
			findJuvenile();
			//add them to the picker
			/*
			for (int i = 0; i < App.juvenilesInRoom.Count; i++)
				detaineePicker.Items.Add((juvenilesInRoom[i].firstName + " " + juvenilesInRoom[i].lastName));
				*/

		}//end handleDetaineePicker

        void bogusPicker(object s, EventArgs args)
        {

            detaineePicker.Items.Clear();
            detaineePicker.Items.Add("MICHAEL SCOFIELD");
            detaineePicker.Items.Add("NEAL CAFFREY");



        }

		//GETs the list of detainees from the DB and populates our local list
		//DOES NOT populate a picker..--we need a method to load detaineePicker once the room has
		//been selected
		public void loadJuveniles()
		{
			//retrieve all the potential rooms in the facility
			try
			{
				//for testing purposes*******
				for (int i = 0; i < App.listOfJuveniles.Count; i++)
				{
					detaineePicker.Items.Add((App.listOfJuveniles[i].firstName) + " " + (App.listOfJuveniles[i].lastName));
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"					ERROR{0}", ex.Message);

			}

		}





		//loads the list of rooms from the DB and populates the roomPicker
		//EVENTUALLY----we need to NOT LOAD the list into the picker and only populate
		//the field once the barcode has been scanned and evaluated as a legitimate barcode
		public void loadRooms()
		{
			//retrieve all the potential rooms in the facility
			try
			{
					//eventually we have to go back and turn this picker into an entry so they can't change the 
					//room unless they scan another
					for (int i = 0; i < App.listOfRooms.Count; i++)
					{
						roomPicker.Items.Add(App.listOfRooms[i].roomName);
					}
					//set the first detainee(s) from the default room for the picker

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"					ERROR{0}", ex.Message);

			}

		}








		public void loadObservationTypes()
		{


			//retrieve all the potential MealTypes and store them in listOfMealTypes
			try
			{
				for (int i = 0; i < App.listOfObservationTypes.Count; i++)
					{
						observationPicker.Items.Add(App.listOfObservationTypes[i].description);
					}


			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"					ERROR{0}", ex.Message);

			}

		}


	}
}

