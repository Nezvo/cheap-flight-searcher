using LowFareFlightSearcher.Base;
using LowFareFlightSearcher.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LowFareFlightSearcher.Model
{
	class FlightSearch : NotifyPropertyChanged
	{
		private MainWindowViewModel _viewModel;
		public FlightSearch(MainWindowViewModel viewModel)
		{
			_viewModel = viewModel;
		}

		private string _origin = "daw";
		private string _destination = "daw";
		private DateTime _departureDate = DateTime.Now;
		private DateTime _returnDate = DateTime.Now;
		private int _adultsNumber = 1;
		private int _childrenNumber;
		private int _infantsNumber;
		private string _currency;


		public string Origin { get { return _origin; } set { _origin = value; Notify(); } }
		public string Destination { get { return _destination; } set { _destination = value; Notify(); } }
		public DateTime DepartureDate { get { return _departureDate; } set { _departureDate = value; Notify(); } }
		public DateTime ReturnDate { get { return _returnDate; } set { _returnDate = value; Notify(); } }
		public int AdultsNumber { get { return _adultsNumber; } set { _adultsNumber = value; Notify(); } }
		public int ChildrenNumber { get { return _childrenNumber; } set { _childrenNumber = value; Notify(); } }
		public int InfantsNumber { get { return _infantsNumber; } set { _infantsNumber = value; Notify(); } }
		public string Currency { get { return _currency; } set { _currency = value; Notify(); } }


		public bool CanUpdate()
		{
			if (string.IsNullOrEmpty(this._origin) || string.IsNullOrEmpty(this._destination) || string.IsNullOrEmpty(this._currency) || this._departureDate == null || this._returnDate == null)
			{
				return false;
			}
			else if (this._departureDate < DateTime.Now || this._returnDate < this._departureDate)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
