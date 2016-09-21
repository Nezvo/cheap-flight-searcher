using LowFareFlightSearcher.Base;
using System;

namespace LowFareFlightSearcher.Model
{
	public class FlightSearch : NotifyPropertyChanged
	{
		private string _origin;
		private string _destination;
		private DateTime _departureDate = DateTime.Now;
		private DateTime _returnDate = DateTime.Now;
		private int _adultsNumber = 1;
		private int _childrenNumber;
		private int _infantsNumber;
		private string _currency;


		public string Origin
		{
			get { return _origin; }
			set
			{
				_origin = value;
				Notify();
			}
		}

		public string Destination
		{
			get { return _destination; }
			set
			{
				_destination = value;
				Notify();
			}
		}

		public DateTime DepartureDate
		{
			get { return _departureDate; }
			set
			{
				_departureDate = value;
				Notify();
			}
		}

		public DateTime ReturnDate
		{
			get { return _returnDate; }
			set
			{
				_returnDate = value;
				Notify();
			}
		}

		public int AdultsNumber
		{
			get { return _adultsNumber; }
			set
			{
				_adultsNumber = value;
				Notify();
			}
		}

		public int ChildrenNumber
		{
			get { return _childrenNumber; }
			set
			{
				_childrenNumber = value;
				Notify();
			}
		}

		public int InfantsNumber
		{
			get { return _infantsNumber; }
			set
			{
				_infantsNumber = value;
				Notify();
			}
		}

		public string Currency
		{
			get { return _currency; }
			set
			{
				_currency = value;
				Notify();
			}
		}
	}
}
