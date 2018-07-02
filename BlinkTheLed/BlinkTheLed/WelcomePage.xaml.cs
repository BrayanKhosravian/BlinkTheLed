using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Bluetooth;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlinkTheLed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{

		//  private BluetoothSocket _btSocket = ShowPairedListView._socket;

		//  private CustomBluetoothManager _customBluetoothManager; 

		// private Stream _outStream;

		private readonly CustomBluetoothManager _customBluetoothManager;


		public WelcomePage ()
		{
			InitializeComponent ();

		    _customBluetoothManager = (Application.Current as App).g_CustomBluetoothManager;

		}

		private async void Bluetooth_Options(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new BlinkTheLed.BluetoothPage());

		}

		private void Button_One(object sender, EventArgs e)
		{
			_customBluetoothManager.DoSendStream("1");

			
		}

		private void Button_Two(object sender, EventArgs e)
		{
			_customBluetoothManager.DoSendStream("0");

		}

		private void Button_Three(object sender, EventArgs e)
		{
			
		}
	}
}