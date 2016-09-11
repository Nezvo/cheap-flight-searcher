using LowFareFlightSearcher.Airport_Autocomplete;
using LowFareFlightSearcher.Base;
using LowFareFlightSearcher.Business;
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
	internal class MainWindowViewModel : NotifyPropertyChanged
	{
		private string _selectedCountryOrigin;
		private string _selectedCountryDestination;
		private IEnumerable<AirportAutocomplete> _iataOrigin;
		private IEnumerable<AirportAutocomplete> _iataDestination;
		
		public const string ApiKey = "crI0rvRbZjGlOo2HVBMBRiwSlA0SGbdI";
		public IList<string> Currency { get; set; }
		public IEnumerable<string> Countries { get; set; }
		public IEnumerable<AirportAutocomplete> IataOrigin
		{
			get
			{
				return _iataOrigin;
			}
			set
			{
				_iataOrigin = value;
				Notify();
			}
		}
		public IEnumerable<AirportAutocomplete> IataDestination
		{
			get
			{
				return _iataDestination;
			}
			set
			{
				_iataDestination = value;
				Notify();
			}
		}
		public string SelectedCountryOrigin
		{
			get
			{
				return _selectedCountryOrigin;
			}
			set
			{
				_selectedCountryOrigin = value;
				IataOrigin = Task.Run(() => AirportManager.GetIataCodes(GetAirportOriginParametersUrl())).Result;
			}
		}
		public string SelectedCountryDestination
		{
			get
			{
				return _selectedCountryDestination;
			}
			set
			{
				_selectedCountryDestination = value;
				IataDestination = Task.Run(() => AirportManager.GetIataCodes(GetAirportDestinationParametersUrl())).Result;
			}
		}

		public MainWindowViewModel()
		{
			Currency = new List<string>() { "HRK", "EUR", "USD" };
			Countries = AirportManager.GetCpuntries();
			//_FlightSearch = new FlightSearch();
			//_FlightsResults = new FlightsResults();
			//_FlightResult = new FlightResult();
			//_AirportAutocomplete = new AirportAutocomplete();
			//_Airports = new Airports();
			FlightSearch = new FlightSearch();
			FlightResult = new FlightResult();
			AirportAutocomplete = new AirportAutocomplete();
			//Airports = new Airports();
		}

		//IEnumerable<AirportAutocomplete>

		//private FlightSearch _FlightSearch;
		public FlightSearch FlightSearch{ get; }

		//private FlightResult _FlightResult;
		public FlightResult FlightResult{ get; }

		private SearchCommand _searchCommand;
		public SearchCommand SearchCommand
		{
			get
			{
				if (_searchCommand == null)
					_searchCommand = new SearchCommand(this);

				return _searchCommand;
			}
		}

		//private FlightsResults _FlightsResults;
		public FlightsResults FlightsResults{ get; set; }

		//private Airports _Airports;
		//public Airports Airports{ get; }

		//private AirportAutocomplete _AirportAutocomplete;
		public AirportAutocomplete AirportAutocomplete{	get; set;}

		public string GetFlightParametersUrl()
		{
			string parameters = $"?origin={FlightSearch.Origin}&destination={FlightSearch.Destination}&departure_date={FlightSearch.DepartureDate.ToString("yyyy-MM-dd")}&return_date={FlightSearch.ReturnDate.ToString("yyyy-MM-dd")}&adults={FlightSearch.AdultsNumber}&childred={FlightSearch.ChildrenNumber}&infants={FlightSearch.InfantsNumber}&currency={FlightSearch.Currency}&number_of_results=3&apikey={ApiKey}";

			return parameters;
		}

		public string GetAirportOriginParametersUrl()
		{
			string parameters = $"?apikey={ApiKey}&country={SelectedCountryOrigin.Substring(SelectedCountryOrigin.Length - 2)}";

			return parameters;
		}

		public string GetAirportDestinationParametersUrl()
		{
			string parameters = $"?apikey={ApiKey}&country={SelectedCountryDestination.Substring(SelectedCountryDestination.Length - 2)}";

			return parameters;
		}

		public int CountConnectingFlightsInbound()
		{
			List<Result> rezultati = FlightsResults.Results;
			return 1;
		}
	}
}
