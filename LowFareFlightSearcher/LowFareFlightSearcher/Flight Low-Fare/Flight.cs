using Newtonsoft.Json;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	class Flight
	{
		[JsonProperty("departs_at")]
		public string DepartsAt { get; set; }
		[JsonProperty("arrives_at")]
		public string ArrivesAt { get; set; }
		[JsonProperty("origin")]
		public Origin Origin { get; set; }
		[JsonProperty("destination")]
		public Destination Destination { get; set; }
		[JsonProperty("marketing_airline")]
		public string MarketingAirline { get; set; }
		[JsonProperty("operating_airline")]
		public string OperatingAirline { get; set; }
		[JsonProperty("flight_number")]
		public string FlightNumber { get; set; }
		[JsonProperty("aircraft")]
		public string Aircraft { get; set; }
		[JsonProperty("booking_info")]
		public Booking_info BookingInfo { get; set; }
	}
}
