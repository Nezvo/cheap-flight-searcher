using LowFareFlightSearcher.Model;
using System;
using System.Collections.Generic;

namespace LowFareFlightSearcher.Business
{
	[Serializable]
	public class Flights
	{
		public string Key { get; set; }

		public List<FlightResult> Results { get; set; }

		public Flights()
		{
			Results = new List<FlightResult>();
		}
	}
}
