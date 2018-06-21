using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Acr.Reflection;
using Android.Bluetooth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlinkTheLed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {
       // private ObservableCollection<DeviceInformation> Items { get; set; }
        private  ObservableCollection<string> Items { get; set; }

        private readonly BluetoothAdapter _manager;
        private ICollection<BluetoothDevice> _bondedDevices;

        public ListViewPage1()
        {
            InitializeComponent();

            _manager = BluetoothAdapter.DefaultAdapter;
            _bondedDevices = _manager.BondedDevices;

            
            int i = 0;

            string[] _listDevice = new string[_bondedDevices.Count];
            // List<DeviceInformation> list = new List<DeviceInformation>();
            // DeviceInformation deviceInformation = new DeviceInformation();

            foreach (var device in _bondedDevices)
            {
                _listDevice[i] = device.Name  + "   -   " + device.Address;
                
             // deviceInformation._deviceName = item.Name;
             // deviceInformation._deviceMAC = item.Address;

            //  list.Add(deviceInformation);
                i++;
            }

          //  Items = new ObservableCollection<DeviceInformation>(list);
            Items = new ObservableCollection<string>(_listDevice);
			
			MyListView.ItemsSource = Items;
        }


        private class DeviceInformation
        {
            public string _deviceName { get; set; }
            public string _deviceMAC { get; set; }
        }
        

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", $"An item was tapped. - {e.Item} Hash: {e.GetHashCode()}", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
