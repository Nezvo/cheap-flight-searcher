using Newtonsoft.Json;
using System.Collections.Generic;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	class Inbound
	{
		[JsonProperty("flights")]
		public List<Flight> Flights { get; set; }
	}
}
