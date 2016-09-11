using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	class FlightResult
	{
		public string Origin { get; set; }

		public string Destination { get; set; }

		public DateTime DepartsAt { get; set; }

		public DateTime ArrivesAt { get; set; }

		public int PassengerCount { get; set; }

		public decimal Currency { get; set; }

		public decimal TotalPrice { get; set; }
	}
}
