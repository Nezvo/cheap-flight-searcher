using LowFareFlightSearcher.Flight_Low_Fare;
using LowFareFlightSearcher.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LowFareFlightSearcher.Commands
{
	class SearchCommand : ICommand
	{
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
			return _viewModel.flightSearch.CanUpdate();
		}

		public void Execute(object parameter)
		{
			Console.WriteLine(_viewModel.flightSearch.AdultsNumber);
			Console.WriteLine(_viewModel.flightSearch.ChildrenNumber);
			Console.WriteLine(_viewModel.flightSearch.InfantsNumber);
			Console.WriteLine(_viewModel.flightSearch.DepartureDate.ToString("yyyy-MM-dd"));
			Console.WriteLine(_viewModel.flightSearch.ReturnDate.ToString("yyyy-MM-dd"));
			Console.WriteLine(_viewModel.flightSearch.Origin);
			Console.WriteLine(_viewModel.flightSearch.Destination);
			Console.WriteLine(_viewModel.Airports.SelectedCountryOrigin);
			Console.WriteLine(_viewModel.flightSearch.Currency);
			Submit();
		}

		public async void Submit()
		{
			//await Task.Delay(3000);
			//Console.WriteLine("gotov thread");

			//using (HttpClient client = new HttpClient())
			//{
			//	client.BaseAddress = new Uri("https://api.sandbox.amadeus.com/v1.2/flights/low-fare-search");
			//	client.DefaultRequestHeaders.Accept.Clear();
			//	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			//	HttpResponseMessage response = await client.GetAsync(_viewModel.GetFlightParametersUrl());

			//	if (response.IsSuccessStatusCode)
			//	{
			//		_viewModel.RootObject = await response.Content.ReadAsAsync<RootObject>();
			//	}
			//}

		}

	}
}
