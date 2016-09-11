using LowFareFlightSearcher.Airport_Autocomplete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace LowFareFlightSearcher.Business
{
	static class AirportManager
	{
		private const string AmadeusAutocompleteUri = "https://api.sandbox.amadeus.com/v1.2/airports/autocomplete";
		public static IEnumerable<string> GetCpuntries()
		{
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\country codes.txt");
			return File.ReadAllLines(path);
		}

		public static async Task<IEnumerable<AirportAutocomplete>> GetIataCodes(string parameters)
		{
			IEnumerable<AirportAutocomplete> retVal = null;

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(AmadeusAutocompleteUri);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(parameters);

				if (response.IsSuccessStatusCode)
				{
					retVal = await response.Content.ReadAsAsync<IEnumerable<AirportAutocomplete>>();
				}
			}

			return retVal;
		}
	}
}
