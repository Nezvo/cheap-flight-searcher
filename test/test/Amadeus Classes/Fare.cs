using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	public class Fare
	{
		[JsonProperty("total_price")]
		public string TotalPrice { get; set; }
		[JsonProperty("price_per_adult")]
		public Price_per_adult PricePerAdult { get; set; }
		[JsonProperty("restrictions")]
		public Restrictions Restrictions { get; set; }
	}
}
