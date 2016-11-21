using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using System.Diagnostics;


namespace JCSMobileAug2016
{
	
	public class MealTypeService
	{
		
		HttpClient client;

		public MealTypeService()
		{
		}


		public async Task<List<MealType>> GetMealTypesAsync()
		{
			//declare a list of MealTypes
			List<MealType> listOfMealTypes = new List<MealType>();


			//var response = await client.GetStringAsync(string.Format("http://vtestweb-01.proware.com/jcsAPI/api/MealType"));

			try
			{
				var uri = new Uri(string.Format("http://vtestweb-01.proware.com/jcsAPI/api/MealType", string.Empty));
				var response = await client.GetAsync(uri);

				//see what we got
				//System.Diagnostics.Debug.WriteLine(response);
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

			return listOfMealTypes;
		}


		public async Task<String> GetString()
		{
			HttpResponseMessage response = await client.GetAsync("http://vtestweb-01.proware.com/jcsAPI/api/MealType/get");
			//see what we got
			//System.Diagnostics.Debug.WriteLine(response);
			//List<MealType> listOfMealTypes = JsonConvert.DeserializeObject<List<MealType>>(response);
			//return listOfMealTypes;
			return await response.Content.ReadAsStringAsync();

		}

	}
}
