using LowFareFlightSearcher.ViewModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LowFareFlightSearcher.Flight_Low_Fare
{
	class RootObject
	{
		private MainWindowViewModel _viewModel;

		public RootObject(MainWindowViewModel viewModel)
		{
			_viewModel = viewModel;
		}

		[JsonProperty("currency")]
		public string Currency { get; set; }
		[JsonProperty("results")]
		public List<Result> Results { get; set; }
	}
}
