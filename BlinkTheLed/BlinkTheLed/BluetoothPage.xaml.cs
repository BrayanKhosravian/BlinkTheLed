using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.Reflection;
using Android.Bluetooth;
using Android.Bluetooth.LE;
using Android.Content;
//using ImageIO;
using Plugin.BluetoothLE;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace BlinkTheLed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BluetoothPage : ContentPage
	{

	    private readonly BluetoothAdapter _manager;
        

        public BluetoothPage ()
		{
			InitializeComponent ();
		 
            this._manager = BluetoothAdapter.DefaultAdapter;

		    if (this._manager != null)
		    {
                // Device does not support bluetooth
		    }
		}


	    private void Button_BT_TurnOn(object sender, EventArgs e)
	    {
	        if (!_manager.IsEnabled) _manager.Enable();
        }


	    private void Button_BT_TurnOff(object sender, EventArgs e)
	    {
	        if (_manager.IsEnabled) _manager.Disable();
	    }

	    private async void Button_BT_ShowPaired(object sender, EventArgs e)
	    {
	       // ICollection<BluetoothDevice> listOfPaireDevices = _manager.BondedDevices;


	        // await Navigation.PushAsync(new Page1());
	        await Navigation.PushAsync(new ShowPairedListView());
	    }

	    private void Button_BT_Connect(object sender, EventArgs e)
	    {
	        
	    }

	    private void Button_BT_Discover(object sender, EventArgs e)
	    {
	        
	    }
	}
}