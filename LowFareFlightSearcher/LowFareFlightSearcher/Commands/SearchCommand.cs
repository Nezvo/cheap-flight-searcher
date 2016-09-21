using LowFareFlightSearcher.Business;
using LowFareFlightSearcher.Flight_Low_Fare;
using LowFareFlightSearcher.Model;
using LowFareFlightSearcher.View;
using LowFareFlightSearcher.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;

namespace LowFareFlightSearcher.Commands
{
	public class SearchCommand : ICommand
	{
		private const string AmadeusFlightUri = "https://api.sandbox.amadeus.com/v1.2/flights/low-fare-search";

		public static Dictionary<string, Flights> FlightsCache = new Dictionary<string, Flights>();
		private MainWindowViewModel _viewModel;

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public SearchCommand(MainWindowViewModel viewModel)
		{
			_viewModel = viewModel;
		}

		public bool CanExecute(object parameter)
		{
			return !((string.IsNullOrEmpty(_viewModel.FlightSearch.Origin)
				|| string.IsNullOrEmpty(_viewModel.FlightSearch.Destination)
				|| string.IsNullOrEmpty(_viewModel.FlightSearch.Currency)
				|| _viewModel.FlightSearch.DepartureDate == null
				|| _viewModel.FlightSearch.ReturnDate == null
				|| _viewModel.FlightSearch.DepartureDate < DateTime.Now.Date
				|| _viewModel.FlightSearch.ReturnDate < _viewModel.FlightSearch.DepartureDate));
		}

		public void Execute(object parameter)
		{
			Flights flights = null;
			string key = GenerateUniqueKey();
			if (!FlightsCache.ContainsKey(key))
			{
				FlightsResults flightsResults = Task.Run(() => Search()).Result;
				flights = Result(flightsResults);
				flights.Key = key;
				FlightsCache.Add(key, flights);
			}
			else
			{
				flights = FlightsCache[key];
			}

			DisplayFlights displayFlightsWindow = new DisplayFlights();
			((DisplayFlightsViewModel)displayFlightsWindow.DataContext).FlightResults = flights.Results;
			displayFlightsWindow.ShowDialog();
		}

		public Flights Result(FlightsResults oResults)
		{
			Flights retVal = new Flights();

			if (oResults != null)
			{
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
					itemresult.TotalPrice = Decimal.Parse(item.Fare.TotalPrice, CultureInfo.InvariantCulture);
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

					retVal.Results.Add(itemresult);
				}
			}

			return retVal;
		}

		public async Task<FlightsResults> Search()
		{
			FlightsResults retVal = null;

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(AmadeusFlightUri);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(_viewModel.GetFlightParametersUrl());

				if (response.IsSuccessStatusCode)
				{
					retVal = await response.Content.ReadAsAsync<FlightsResults>();
				}
			}

			return retVal;
		}

		public string GenerateUniqueKey()
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
