using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	class Program
	{
		static void Main(string[] args)
		{

			//elements[0]: Airport ID -Unique OpenFlights identifier for this airport.
			//elements[1]: Name - Name of airport.May or may not contain the City name.
			//elements[2]: City - Main city served by airport.May be spelled differently from Name.
			//elements[3]: Country -Country or territory where airport is located.
			//elements[4]: IATA / FAA - 3 - letter FAA code, for airports located in Country "United States of America". 3 - letter IATA code, for all other airports.Blank if not assigned.
			//elements[5]: ICAO - 4 - letter ICAO code. Blank if not assigned.
			//elements[6]: Latitude - Decimal degrees, usually to six significant digits.Negative is South, positive is North.
			//elements[7]: Longitude - Decimal degrees, usually to six significant digits.Negative is West, positive is East.
			//elements[8]: Altitude - In feet.
			//elements[9]: Timezone - Hours offset from UTC.Fractional hours are expressed as decimals, eg.India is 5.5.
			//elements[10]: DST - Daylight savings time. One of E(Europe), A(US / Canada), S(South America), O(Australia), Z(New Zealand), N(None) or U (Unknown).

			string[] elements;

			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\airports.txt");
			List<string> airportParse = File.ReadAllLines(path).ToList();

			List<string> countries = new List<string>();
			List<string> result = new List<string>();

			airportParse.ForEach(i =>
			{
				elements = i.Split(',');
				countries.Add(elements[3]);

				if (elements[4] == "Croatia" && !string.IsNullOrWhiteSpace(elements[4]))
				{
					result.Add(elements[1] + ", " + elements[2] + "-" + elements[4]);
				}
			}
			);

			List<string> distinctCountries = countries.Distinct().OrderBy(i => i).ToList();
			distinctCountries.ForEach(i => Console.WriteLine(i));
			//result.ForEach(i => Console.WriteLine(i));

		}
	}
}
