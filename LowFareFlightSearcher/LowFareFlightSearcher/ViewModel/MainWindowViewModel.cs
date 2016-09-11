using LowFareFlightSearcher.Airport_Autocomplete;
using LowFareFlightSearcher.Base;
using LowFareFlightSearcher.Commands;
using LowFareFlightSearcher.Flight_Low_Fare;
using LowFareFlightSearcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LowFareFlightSearcher.ViewModel
{
	internal class MainWindowViewModel
	{
		
		public const string ApiKey = "crI0rvRbZjGlOo2HVBMBRiwSlA0SGbdI";
		public IList<string> Currency { get; set; }

		public MainWindowViewModel()
		{
			Currency = new List<string>() { "HRK", "EUR", "USD" };
			//_FlightSearch = new FlightSearch(this);
		}

		private FlightSearch _FlightSearch;
		public FlightSearch flightSearch
		{
			get
			{
				if (_FlightSearch == null)
					_FlightSearch = new FlightSearch(this);

				return _FlightSearch;
			}
		}

		private FlightResult _FlightResult;
		public FlightResult FlightResult
		{
			get
			{
				if (_FlightResult == null)
					_FlightResult = new FlightResult(this);

				return _FlightResult;
			}
		}

		private SearchCommand _TestCommand;
		public SearchCommand TestCommand
		{
			get
			{
				if (_TestCommand == null)
					_TestCommand = new SearchCommand(this);

				return _TestCommand;
			}
		}

		private RootObject _RootObject;
		public RootObject RootObject
		{
			get
			{
				if (_RootObject == null)
					_RootObject = new RootObject(this);

				return _RootObject;
			}

			set
			{
				_RootObject = value;
			}
		}

		private Airports _Airports;
		public Airports Airports
		{
			get
			{
				if (_Airports == null)
					_Airports = new Airports(this);

				return _Airports;
			}
		}

		private AirportAutocomplete _AirportAutocomplete;
		public AirportAutocomplete AirportAutocomplete
		{
			get
			{
				if (_AirportAutocomplete == null)
					_AirportAutocomplete = new AirportAutocomplete(this);

				return _AirportAutocomplete;
			}
			set
			{
				_AirportAutocomplete = value;
			}
		}

		public string GetFlightParametersUrl()
		{
			string parameters = $"?origin={_FlightSearch.Origin}&destination={_FlightSearch.Destination}&departure_date={_FlightSearch.DepartureDate.ToString("yyyy-MM-dd")}&return_date={_FlightSearch.ReturnDate.ToString("yyyy-MM-dd")}&adults={_FlightSearch.AdultsNumber}&childred={_FlightSearch.ChildrenNumber}&infants={_FlightSearch.InfantsNumber}&currency={_FlightSearch.Currency}&number_of_results=3&apikey={ApiKey}";

			return parameters;
		}

		public string GetAirportOriginParametersUrl()
		{
			string parameters = $"?apikey={ApiKey}&country={_Airports.SelectedCountryOrigin.Substring(_Airports.SelectedCountryOrigin.Length - 2)}";

			return parameters;
		}

		public int CountConnectingFlightsInbound()
		{
			List<Result> rezultati = _RootObject.Results;
			return 1;
		}
	}
}
