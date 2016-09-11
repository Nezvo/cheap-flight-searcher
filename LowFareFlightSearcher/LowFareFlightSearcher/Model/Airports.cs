//using LowFareFlightSearcher.Base;
//using LowFareFlightSearcher.ViewModel;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Reflection;

//namespace LowFareFlightSearcher.Model
//{
//	class Airports
//	{

//		public Airports()
//		{
//			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\country codes.txt");
//			_countries = File.ReadAllLines(path).ToList();
//		}

//		public async void GetIataCodes()
//		{
//			using (httpclient client = new httpclient())
//			{
//				client.baseaddress = new uri("https://api.sandbox.amadeus.com/v1.2/airports/autocomplete");
//				client.defaultrequestheaders.accept.clear();
//				client.defaultrequestheaders.accept.add(new mediatypewithqualityheadervalue("application/json"));

//				httpresponsemessage response = await client.getasync(_viewmodel.getairportoriginparametersurl());

//				if (response.issuccessstatuscode)
//				{
//					_viewmodel.airportautocomplete = await response.content.readasasync<airportautocomplete>();
//				}
//			}
//		}
//	}

//}
