using LowFareFlightSearcher.Airport_Autocomplete;
using LowFareFlightSearcher.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LowFareFlightSearcher.Business
{
	static public class AirportManager
	{
		private const string AmadeusAutocompleteUri = "https://api.sandbox.amadeus.com/v1.2/airports/autocomplete";
		static Dictionary<string, IEnumerable<AirportAutocomplete>> IataCache = new Dictionary<string, IEnumerable<AirportAutocomplete>>();

		public static IEnumerable<string> GetCountries()
		{
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\country codes.txt");
			return File.ReadAllLines(path);
		}

		public static async Task<IEnumerable<AirportAutocomplete>> GetIataCodes(string parameters)
		{
			IEnumerable<AirportAutocomplete> retVal = null;

			if (!String.IsNullOrEmpty(parameters))
			{
				string key = parameters.Substring(parameters.Length - 2);

				if (IataCache.ContainsKey(key))
				{
					retVal = IataCache[key];
				}
				else
				{
					using (HttpClient client = new HttpClient())
					{
						client.BaseAddress = new Uri(AmadeusAutocompleteUri);
						client.DefaultRequestHeaders.Accept.Clear();
						client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

						HttpResponseMessage response = await client.GetAsync(parameters);

						if (response.IsSuccessStatusCode)
						{
							retVal = await response.Content.ReadAsAsync<IEnumerable<AirportAutocomplete>>();
							IataCache.Add(key, retVal);
						}
					}
				}
			}

			return retVal;
		}

		public static void SaveFlights()
		{
			List<Flights> f = SearchCommand.FlightsCache.Values.ToList();
			XmlSerializer serializer = new XmlSerializer(typeof(List<Flights>));

			using (StringWriter sw = new StringWriter())
			{
				using (XmlWriter writer = XmlWriter.Create(sw))
				{
					serializer.Serialize(writer, f);
					var xml = sw.ToString();
					File.WriteAllText(@"Data\History.xml", xml);
				}
			}
		}

		public static void ReadFlights()
		{
			List<Flights> flightsCollection = null;
			XmlSerializer serializer = new XmlSerializer(typeof(List<Flights>));
			using (StreamReader reader = new StreamReader(@"Data\History.xml"))
			{
				flightsCollection = (List<Flights>)serializer.Deserialize(reader);
				reader.Close();
			}

			if (flightsCollection != null)
			{
				foreach (Flights f in flightsCollection)
				{
					SearchCommand.FlightsCache.Add(f.Key, f);
				}

			}
		}
	}
}
