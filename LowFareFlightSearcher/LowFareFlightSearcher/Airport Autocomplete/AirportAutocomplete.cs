using LowFareFlightSearcher.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowFareFlightSearcher.Airport_Autocomplete
{
	class AirportAutocomplete
	{
		private MainWindowViewModel _viewModel;

		public AirportAutocomplete(MainWindowViewModel viewModel)
		{
			_viewModel = viewModel;
		}

		[JsonProperty("value")]
		public string Value { get; set; }
		[JsonProperty("label")]
		public string Label { get; set; }
	}
}
