using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.Reflection;
using Android.Bluetooth;
using Android.Bluetooth.LE;
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

	    private BluetoothAdapter _manager = BluetoothAdapter.DefaultAdapter;

        

        public BluetoothPage ()
		{
			InitializeComponent ();
		   // _manager = (BluetoothManager) Android.App.Application.Context.GetSystemService(Android.Content.Context.BluetoothService);
		    // _manager = BluetoothAdapter.DefaultAdapter;
		}


	    private void Bluetooth_TurnOn(object sender, EventArgs e)
	    {
	        if (!_manager.IsEnabled) _manager.Enable();
            
	    }

	    private void Bluetooth_TurnOff(object sender, EventArgs e)
	    {
	        if (_manager.IsEnabled) _manager.Disable();
	    }

	    private void Bluetooth_GetVisible(object sender, EventArgs e)
	    {
	        if (_manager.IsEnabled)
	        {
	           
	           
	        }
	    }

	    private void Bluetooth_Scan(object sender, EventArgs e)
	    {
	        if (_manager.IsEnabled && !_manager.IsDiscovering)
	        {
	            _manager.StartDiscovery();

	        }
        }

	    private void Blutooth_ShowPaired(object sender, EventArgs e)
	    {
	        
	    }

	    private void Bluetooth_Connect(object sender, EventArgs e)
	    {
	        
	    }
	}
}