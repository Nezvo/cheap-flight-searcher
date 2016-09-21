using Newtonsoft.Json;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	public class Itinerary
	{
		[JsonProperty("outbound")]
		public Outbound Outbound { get; set; }
		[JsonProperty("inbound")]
		public Inbound Inbound { get; set; }
	}
}
