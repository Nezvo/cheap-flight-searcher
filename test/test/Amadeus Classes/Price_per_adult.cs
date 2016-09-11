using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	public class Price_per_adult
	{
		[JsonProperty("total_fare")]
		public string TotalFare { get; set; }
		[JsonProperty("tax")]
		public string Tax { get; set; }
	}
}
