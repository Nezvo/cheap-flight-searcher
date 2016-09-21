using LowFareFlightSearcher.Base;
using LowFareFlightSearcher.Model;
using System.Collections.Generic;

namespace LowFareFlightSearcher.ViewModel
{
	class DisplayFlightsViewModel : NotifyPropertyChanged
	{
		private IEnumerable<FlightResult> _flightResults;
		public IEnumerable<FlightResult> FlightResults
		{
			get { return _flightResults; }
			set
			{
				_flightResults = value;
				Notify();
			}
		}
	}
}
