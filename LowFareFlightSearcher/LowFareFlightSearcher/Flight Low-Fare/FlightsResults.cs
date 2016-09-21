using Newtonsoft.Json;
using System.Collections.Generic;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	public class FlightsResults
	{
		[JsonProperty("currency")]
		public string Currency { get; set; }
		[JsonProperty("results")]
		public List<Result> Results { get; set; }
	}
}
