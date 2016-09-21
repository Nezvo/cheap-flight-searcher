using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LowFareFlightSearcher.Base
{
	public abstract class NotifyPropertyChanged : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		public void Notify([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
