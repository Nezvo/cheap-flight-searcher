using Newtonsoft.Json;

namespace LowFareFlightSearcher.Airport_Autocomplete
{
	public class AirportAutocomplete
	{
		[JsonProperty("value")]
		public string Value { get; set; }
		[JsonProperty("label")]
		public string Label { get; set; }
	}
}
