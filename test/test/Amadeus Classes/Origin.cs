using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	public class Origin
	{
		[JsonProperty("airport")]
		public string Airport { get; set; }
		[JsonProperty("terminal")]
		public string Terminal { get; set; }
	}
}
