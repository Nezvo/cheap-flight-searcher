using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	public class Result
	{
		[JsonProperty("itineraries")]
		public List<Itinerary> Itineraries { get; set; }
		[JsonProperty("fare")]
		public Fare Fare { get; set; }
	}
}
