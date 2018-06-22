using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Bluetooth;
using BlinkTheLed.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlinkTheLed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
	    private readonly BluetoothAdapter _manager;
	    private readonly ICollection<BluetoothDevice> _bondedDevices;

        private readonly List<Contact> _listOfDevices = new List<Contact>();

		public Page1 ()
		{
			InitializeComponent ();

            _manager = BluetoothAdapter.DefaultAdapter;
		    _bondedDevices = _manager.BondedDevices;

		    foreach (var device in _bondedDevices)
		    {
		        _listOfDevices.Add(new Contact(device.Name, device.Address));
		    }

		    MyListView.ItemsSource = _listOfDevices;

		}
	}
}