using LowFareFlightSearcher.Airport_Autocomplete;
using LowFareFlightSearcher.Base;
using LowFareFlightSearcher.Business;
using LowFareFlightSearcher.Commands;
using LowFareFlightSearcher.Flight_Low_Fare;
using LowFareFlightSearcher.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowFareFlightSearcher.ViewModel
{
	public class MainWindowViewModel : NotifyPropertyChanged
	{
		public const string ApiKey = "crI0rvRbZjGlOo2HVBMBRiwSlA0SGbdI";

		private string _selectedCountryOrigin;
		private string _selectedCountryDestination;
		//private IEnumerable<AirportAutocomplete> _iataOrigin;
		//private IEnumerable<AirportAutocomplete> _iataDestination;
		private SearchCommand _searchCommand;

		public IList<string> Currency { get; set; }
		public IEnumerable<string> Countries { get; set; }
		public FlightsResults FlightsResults { get; set; }
		public AirportAutocomplete AirportAutocomplete { get; set; }
		public FlightSearch FlightSearch { get; }
		public FlightResult FlightResult { get; }

		public IEnumerable<AirportAutocomplete> IataOrigin
		{
			get
			{
				return Task.Run(() => AirportManager.GetIataCodes(GetAirportOriginParametersUrl())).Result;
			}
			//set
			//{
			//	_iataOrigin = value;
			//	Notify();
			//}
		}

		public IEnumerable<AirportAutocomplete> IataDestination
		{
			get
			{
				return Task.Run(() => AirportManager.GetIataCodes(GetAirportDestinationParametersUrl())).Result;
			}
			//set
			//{
			//	_iataDestination = value;
			//	Notify();
			//}
		}

		public string SelectedCountryOrigin
		{
			get { return _selectedCountryOrigin; }
			set
			{
				_selectedCountryOrigin = value;
				Notify("IataOrigin");
				//IataOrigin = Task.Run(() => AirportManager.GetIataCodes(GetAirportOriginParametersUrl())).Result;
			}
		}

		public string SelectedCountryDestination
		{
			get { return _selectedCountryDestination; }
			set
			{
				_selectedCountryDestination = value;
				Notify("IataDestination");
				//IataDestination = Task.Run(() => AirportManager.GetIataCodes(GetAirportDestinationParametersUrl())).Result;
			}
		}

		public SearchCommand SearchCommand
		{
			get
			{
				if (_searchCommand == null)
					_searchCommand = new SearchCommand(this);

				return _searchCommand;
			}
		}

		public MainWindowViewModel()
		{
			Currency = new List<string>() { "HRK", "EUR", "USD" };
			Countries = AirportManager.GetCountries();
			FlightSearch = new FlightSearch();
			FlightResult = new FlightResult();
			AirportAutocomplete = new AirportAutocomplete();
			AirportManager.ReadFlights();
		}

		public string GetFlightParametersUrl()
		{
			string parameters = $"?origin={FlightSearch.Origin}&destination={FlightSearch.Destination}&departure_date={FlightSearch.DepartureDate.ToString("yyyy-MM-dd")}&return_date={FlightSearch.ReturnDate.ToString("yyyy-MM-dd")}&adults={FlightSearch.AdultsNumber}&childred={FlightSearch.ChildrenNumber}&infants={FlightSearch.InfantsNumber}&currency={FlightSearch.Currency}&number_of_results=3&apikey={ApiKey}";

			return parameters;
		}

		public string GetAirportOriginParametersUrl()
		{
			string parameters = String.Empty;

			if(SelectedCountryOrigin != null)
				parameters = $"?apikey={ApiKey}&country={SelectedCountryOrigin.Substring(SelectedCountryOrigin.Length - 2)}";

			return parameters;
		}

		public string GetAirportDestinationParametersUrl()
		{
			string parameters = String.Empty;

			if(_selectedCountryDestination != null)
				parameters = $"?apikey={ApiKey}&country={SelectedCountryDestination.Substring(SelectedCountryDestination.Length - 2)}";

			return parameters;
		}
	}
}
