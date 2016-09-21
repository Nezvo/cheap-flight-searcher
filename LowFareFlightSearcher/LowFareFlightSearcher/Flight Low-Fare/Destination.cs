using Newtonsoft.Json;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	public class Destination
	{
		[JsonProperty("airport")]
		public string Airport { get; set; }
		[JsonProperty("terminal")]
		public string Terminal { get; set; }
	}
}
