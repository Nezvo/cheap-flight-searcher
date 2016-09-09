using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	class Flight
	{
		public string Origin { get; set; }

		public string Destination { get; set; }

		public DateTime DepartureDate { get; set; }

		public DateTime ReturnDate { get; set; }

		public int AdultsNumber { get; set; }

		public int ChildrenNumber { get; set; }

		public int InfantsNumber { get; set; }

		public decimal Currency { get; set; }
	}
}
