using LowFareFlightSearcher.Airport_Autocomplete;
using LowFareFlightSearcher.Base;
using LowFareFlightSearcher.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LowFareFlightSearcher.Model
{
	class Airports : NotifyPropertyChanged
	{
		private MainWindowViewModel _viewModel;
		public Airports(MainWindowViewModel viewModel)
		{
			_viewModel = viewModel;
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\country codes.txt");
			_countries = File.ReadAllLines(path).ToList();
		}

		private List<string> _countries;
		private string _selectedCountryOrigin;
		private string _selectedCountryDestination;

		public List<string> Countries { get { return _countries; } set { _countries = value; Notify(); } }
		public string SelectedCountryOrigin { get { return _selectedCountryOrigin; } set { _selectedCountryOrigin = value; GetIataCodes(); Notify(); } }
		public string SelecteDCountryDestination { get { return _selectedCountryDestination; } set { _selectedCountryDestination = value; Notify(); } }

		public async void GetIataCodes()
		{
			//using (HttpClient client = new HttpClient())
			//{
			//	client.BaseAddress = new Uri("https://api.sandbox.amadeus.com/v1.2/airports/autocomplete");
			//	client.DefaultRequestHeaders.Accept.Clear();
			//	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			//	HttpResponseMessage response = await client.GetAsync(_viewModel.GetAirportOriginParametersUrl());

			//	if (response.IsSuccessStatusCode)
			//	{
			//		_viewModel.AirportAutocomplete = await response.Content.ReadAsAsync<AirportAutocomplete>();
			//	}
			//}
		}
	}

}
