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

        // private static BluetoothAdapter _manager { get; set; }
        // private ICollection<BluetoothDevice> _bondedDevices { get; }
        // public static BluetoothSocket _socket { get; set; }

        private readonly CustomBluetoothManager _customBluetoothManager;


        public ShowPairedListView()
        {
            InitializeComponent();
            _customBluetoothManager = (Application.Current as App)?.g_CustomBluetoothManager;

            Items = new ObservableCollection<Contact>();

            //_manager = BluetoothAdapter.DefaultAdapter;
            //_bondedDevices = _manager.BondedDevices;

            foreach (BluetoothDevice device in _customBluetoothManager.GetListBondedDevices())
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
                UUID uuid = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");

                BluetoothDevice device = _customBluetoothManager.GetDevice(contact.Mac);
                _customBluetoothManager.DoCancelDiscovery();

                await _customBluetoothManager.DoConnectionInsecure(device, uuid);

                //Deselect Item
                ((ListView) sender).SelectedItem = null;

            }

        }
    }
}
