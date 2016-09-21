using Newtonsoft.Json;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	public class Restrictions
	{
		[JsonProperty("refundable")]
		public bool Refundable { get; set; }
		[JsonProperty("change_penalties")]
		public bool ChangePenalties { get; set; }
	}

}
