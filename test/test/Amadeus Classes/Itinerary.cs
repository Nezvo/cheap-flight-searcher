using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	public class Itinerary
	{
		[JsonProperty("outbound")]
		public Outbound Outbound { get; set; }
		[JsonProperty("inbound")]
		public Inbound Inbound { get; set; }
	}
}
