using Newtonsoft.Json;
using System.Collections.Generic;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	public class Outbound
	{
		[JsonProperty("flights")]
		public List<Flight> Flights { get; set; }
	}
}
