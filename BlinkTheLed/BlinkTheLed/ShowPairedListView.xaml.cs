using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Acr.Reflection;
using Android.Bluetooth;
using Android.Provider;
using BlinkTheLed.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Java.IO;
using Java.Util;
using Console = System.Console;



namespace BlinkTheLed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowPairedListView : ContentPage
	{
		private ObservableCollection<Contact> Items { get; set; }

		private static BluetoothAdapter _manager { get; set; }
	    private ICollection<BluetoothDevice> _bondedDevices { get; }
		public static BluetoothSocket _socket { get; set; }


		public ShowPairedListView()
		{
			InitializeComponent();
			Items = new ObservableCollection<Contact>();

		    _manager = BluetoothAdapter.DefaultAdapter;
		    _bondedDevices = _manager.BondedDevices;

            foreach (BluetoothDevice device in _bondedDevices)
			{
				Items.Add(new Contact(device.Name, device.Address));
			}
			
			MyListView.ItemsSource = Items;
		}

		private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{

			if (e.Item == null)
				return;

			var contact = e.Item as Contact;

			if (contact != null)
			{

			    BluetoothDevice device = _manager.GetRemoteDevice(contact.Mac);
				_manager.CancelDiscovery(); 

				try
				{
					_socket = device.CreateInsecureRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805F9B34FB"));
					_socket.Connect();
				}
				catch (Exception e1)
				{
					Console.WriteLine(e1);
					// throw;
					try
					{
						_socket.Close();
					}
					catch (Exception e2)
					{
						Console.WriteLine(e2);
						// throw;
					}
				}
				
			}

			if (_socket.IsConnected)
			{
				await DisplayAlert("Item Tapped", $"Name: {contact.Name}   +   Address: {contact.Mac}", "OK");
			}
			else
			{
				await DisplayAlert("Status", "Not connected", "OK");
			}

			//Deselect Item
			((ListView)sender).SelectedItem = null;

		}

	}
}
