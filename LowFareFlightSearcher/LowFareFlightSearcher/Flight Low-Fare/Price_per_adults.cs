using Newtonsoft.Json;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	class Price_per_adult
	{
		[JsonProperty("total_fare")]
		public string TotalFare { get; set; }
		[JsonProperty("tax")]
		public string Tax { get; set; }
	}
}
