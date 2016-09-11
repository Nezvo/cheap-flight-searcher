using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	public class Restrictions
	{
		[JsonProperty("refundable")]
		public bool Refundable { get; set; }
		[JsonProperty("change_penalties")]
		public bool ChangePenalties { get; set; }
	}
}
