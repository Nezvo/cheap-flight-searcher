using System;

namespace test
{
	class FlightSearch
	{

		public string Origin { get; set; }

		public string Destination { get; set; }

		public DateTime DepartureDate { get; set; }

		public DateTime ReturnDate { get; set; }

		public int AdultsNumber { get; set; }

		public int ChildrenNumber { get; set; }

		public int InfantsNumber { get; set; }

		public decimal Currency { get; set; }

		public string GetParametersUrl(string apiKey)
		{
			string parametersUrl = $"?origin={Origin}&destination={Destination}&departure_date={DepartureDate}&return_date={ReturnDate}&adults={AdultsNumber}&childred={ChildrenNumber}&infants={InfantsNumber}&currency={Currency}&number_of_results=3&apikey={apiKey}";

			return parametersUrl;
		}
	}
}
