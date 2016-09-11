using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	public class Booking_info
	{
		[JsonProperty("travel_class")]
		public string TravelClass { get; set; }
		[JsonProperty("booking_code")]
		public string BookingCode { get; set; }
		[JsonProperty("seats_remaining")]
		public int SeatsRemaining { get; set; }
	}
}
