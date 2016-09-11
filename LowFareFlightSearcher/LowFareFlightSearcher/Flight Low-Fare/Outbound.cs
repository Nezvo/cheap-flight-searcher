using Newtonsoft.Json;
using System.Collections.Generic;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	class Outbound
	{
		[JsonProperty("flights")]
		public List<Flight> Flights { get; set; }
	}
}
