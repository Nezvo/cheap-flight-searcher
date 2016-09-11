using LowFareFlightSearcher.Base;
using LowFareFlightSearcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowFareFlightSearcher.ViewModel
{
	class DisplayFlightsViewModel : NotifyPropertyChanged
	{
		private IEnumerable<FlightResult> _flightResults;
		public IEnumerable<FlightResult> FlightResults
		{
			get
			{
				return _flightResults;
			}
			set
			{
				_flightResults = value;
				Notify();
			}
		}

		public DisplayFlightsViewModel()
		{

		}
	}
}
