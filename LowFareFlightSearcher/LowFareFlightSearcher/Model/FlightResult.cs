using LowFareFlightSearcher.Base;
using LowFareFlightSearcher.ViewModel;
using System;
using System.ComponentModel;

namespace LowFareFlightSearcher.Model
{	
	class FlightResult : NotifyPropertyChanged
	{
		private string _origin;
		private string _destination;
		private DateTime _departsAt;
		private DateTime _arrivesAt;
		private int _connectingFlightsOutboundCount;
		private int _connectingFlightsInboundCount;
		private int _passengerCount;
		private string _currency;
		private decimal _totalPrice;


		public string Origin { get { return _origin; } set { _origin = value; Notify(); } }
		public string Destination { get { return _destination; } set { _destination = value; Notify(); } }
		public DateTime DepartsAt { get { return _departsAt; } set { _departsAt = value; Notify(); } }
		public DateTime ArrivesAt { get { return _arrivesAt; } set { _arrivesAt = value; Notify(); } }
		public int ConnectingFlightsOutboundCount { get { return _connectingFlightsOutboundCount; } set { _connectingFlightsOutboundCount = value; Notify(); } }
		public int ConnectingFlightsInboundCount { get { return _connectingFlightsInboundCount; } set { _connectingFlightsInboundCount = value; Notify(); } }
		public int PassengerCount { get { return _passengerCount; } set { _passengerCount = value; Notify(); } }
		public string Currency { get { return _currency; } set { _currency = value; Notify(); } }
		public decimal TotalPrice { get { return _totalPrice; } set { _totalPrice = value; Notify(); } }

	}
}
