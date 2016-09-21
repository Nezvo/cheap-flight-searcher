using Newtonsoft.Json;
using System.Collections.Generic;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	public class Inbound
	{
		[JsonProperty("flights")]
		public List<Flight> Flights { get; set; }
	}
}
