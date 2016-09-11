using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	public class Outbound
	{
		[JsonProperty("flights")]
		public List<Flight> Flights { get; set; }
	}
}
