using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	public class Inbound
	{
		[JsonProperty("flights")]
		public List<Flight> Flights { get; set; }
	}
}
