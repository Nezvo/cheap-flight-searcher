using LowFareFlightSearcher.Business;
using System.Windows;

namespace LowFareFlightSearcher
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			AirportManager.SaveFlights();
		}
	}
}
