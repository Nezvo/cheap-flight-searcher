using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	public class RootObject
	{
		[JsonProperty("currency")]
		public string Currency { get; set; }
		[JsonProperty("results")]
		public List<Result> Results { get; set; }
	}
}
