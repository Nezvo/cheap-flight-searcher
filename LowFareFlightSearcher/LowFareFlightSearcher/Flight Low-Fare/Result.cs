using Newtonsoft.Json;
using System.Collections.Generic;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	class Result
	{
		[JsonProperty("itineraries")]
		public List<Itinerary> Itineraries { get; set; }
		[JsonProperty("fare")]
		public Fare Fare { get; set; }
	}
}
