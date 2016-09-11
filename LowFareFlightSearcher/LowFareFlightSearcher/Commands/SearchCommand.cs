using LowFareFlightSearcher.Flight_Low_Fare;
using LowFareFlightSearcher.Model;
using LowFareFlightSearcher.View;
using LowFareFlightSearcher.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LowFareFlightSearcher.Commands
{
	class SearchCommand : ICommand
	{
		private const string AmadeusFlightUri = "https://api.sandbox.amadeus.com/v1.2/flights/low-fare-search";
		static Dictionary<string, FlightsResults> FlightsCache = new Dictionary<string, FlightsResults>();

		private MainWindowViewModel _viewModel;
		public SearchCommand(MainWindowViewModel viewModel)
		{
			_viewModel = viewModel;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
		public bool CanExecute(object parameter)
		{
			return !((string.IsNullOrEmpty(_viewModel.FlightSearch.Origin) || string.IsNullOrEmpty(_viewModel.FlightSearch.Destination)
				|| string.IsNullOrEmpty(_viewModel.FlightSearch.Currency) || _viewModel.FlightSearch.DepartureDate == null
				|| _viewModel.FlightSearch.ReturnDate == null || _viewModel.FlightSearch.DepartureDate < DateTime.Now
				|| _viewModel.FlightSearch.ReturnDate < _viewModel.FlightSearch.DepartureDate));
		}

		public void Execute(object parameter)
		{
			//Console.WriteLine(_viewModel.FlightSearch.AdultsNumber);
			//Console.WriteLine(_viewModel.FlightSearch.ChildrenNumber);
			//Console.WriteLine(_viewModel.FlightSearch.InfantsNumber);
			//Console.WriteLine(_viewModel.FlightSearch.DepartureDate.ToString("yyyy-MM-dd"));
			//Console.WriteLine(_viewModel.FlightSearch.ReturnDate.ToString("yyyy-MM-dd"));
			//Console.WriteLine(_viewModel.FlightSearch.Origin);
			//Console.WriteLine(_viewModel.FlightSearch.Destination);
			//Console.WriteLine(_viewModel.SelectedCountryOrigin);
			//Console.WriteLine(_viewModel.SelectedCountryDestination);
			//Console.WriteLine(_viewModel.FlightSearch.Currency);
			FlightsResults flightsResults = Task.Run(() => Submit()).Result;
			IList<FlightResult> results = Result(flightsResults);
			DisplayFlights displayFlightsWindow = new DisplayFlights();
			((DisplayFlightsViewModel)displayFlightsWindow.DataContext).FlightResults = results;
			displayFlightsWindow.ShowDialog();
		}

		public IList<FlightResult> Result(FlightsResults oResults)
		{
			//List<Tuple<string, IEnumerable<Flight>, IEnumerable<Flight>>> test = new List<Tuple<string, IEnumerable<Flight>, IEnumerable<Flight>>>();
			IList<FlightResult> retVal = new List<FlightResult>();

			foreach (Result item in oResults.Results)
			{
				Itinerary itinerary = item.Itineraries.FirstOrDefault();
				Flight outboundFlight = null;
				Flight inboundFlight = null;
				int inboundCount = 0;
				int outboundCount = 0;

				if (itinerary != null)
				{
					outboundFlight = itinerary.Outbound.Flights.FirstOrDefault();
					inboundFlight = itinerary.Inbound.Flights.FirstOrDefault();

					inboundCount = itinerary.Inbound.Flights.Count;
					outboundCount = itinerary.Outbound.Flights.Count;
				}

				FlightResult itemresult = new FlightResult();
				itemresult.TotalPrice = Decimal.Parse(item.Fare.TotalPrice);
				itemresult.Currency = oResults.Currency;
				itemresult.ConnectingFlightsInboundCount = inboundCount;
				itemresult.ConnectingFlightsOutboundCount = outboundCount;

				if (outboundFlight != null)
					itemresult.DepartsAt = DateTime.Parse(outboundFlight.DepartsAt);

				if (inboundFlight != null)
					itemresult.ArrivesAt = DateTime.Parse(inboundFlight.DepartsAt);

				itemresult.PassengerCount = _viewModel.FlightSearch.AdultsNumber + _viewModel.FlightSearch.ChildrenNumber + _viewModel.FlightSearch.InfantsNumber;
				itemresult.Origin = _viewModel.FlightSearch.Origin;
				itemresult.Destination = _viewModel.FlightSearch.Destination;

				retVal.Add(itemresult);
				//test.Add(new Tuple<string, IEnumerable<Flight>, IEnumerable<Flight>>(money, inboundFlights, outboundFlights));
			}
			return retVal;
		}

		public async Task<FlightsResults> Submit()
		{
			FlightsResults retVal = null;
			string key = generateUniqueKey();

			if (FlightsCache.ContainsKey(key))
			{
				retVal = FlightsCache[key];
			}
			else
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri(AmadeusFlightUri);
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					HttpResponseMessage response = await client.GetAsync(_viewModel.GetFlightParametersUrl());

					if (response.IsSuccessStatusCode)
					{
						retVal = await response.Content.ReadAsAsync<FlightsResults>();
						FlightsCache.Add(key, retVal);
					}
				}
			}
			return retVal;
		}

		public string generateUniqueKey()
		{
			string retVal = null;
			retVal = _viewModel.FlightSearch.Origin + _viewModel.FlightSearch.Destination
				+ _viewModel.FlightSearch.DepartureDate.ToString("yyyy-MM-dd") 
				+ _viewModel.FlightSearch.ReturnDate.ToString("yyyy-MM-dd")
				+ _viewModel.FlightSearch.Currency + _viewModel.FlightSearch.AdultsNumber
				+ _viewModel.FlightSearch.ChildrenNumber + _viewModel.FlightSearch.InfantsNumber
				+ _viewModel.FlightSearch.Currency;
			return retVal;
		}

	}
}
