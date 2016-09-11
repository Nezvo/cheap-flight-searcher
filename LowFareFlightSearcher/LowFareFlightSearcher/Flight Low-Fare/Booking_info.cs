using Newtonsoft.Json;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	class Booking_info
	{
		[JsonProperty("travel_class")]
		public string TravelClass { get; set; }
		[JsonProperty("booking_code")]
		public string BookingCode { get; set; }
		[JsonProperty("seats_remaining")]
		public int SeatsRemaining { get; set; }
	}
}
