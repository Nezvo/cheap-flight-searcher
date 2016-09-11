using Newtonsoft.Json;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	class Fare
	{
		[JsonProperty("total_price")]
		public string TotalPrice { get; set; }
		[JsonProperty("price_per_adult")]
		public Price_per_adult PricePerAdult { get; set; }
		[JsonProperty("restrictions")]
		public Restrictions Restrictions { get; set; }
	}
}
