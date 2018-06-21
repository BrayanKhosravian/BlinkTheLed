using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Android.Bluetooth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlinkTheLed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {
        private ObservableCollection<string> Items { get; set; }
        private readonly BluetoothAdapter _manager;
        private ICollection<BluetoothDevice> _bondedDevices;

        public ListViewPage1()
        {
            InitializeComponent();

            _manager = BluetoothAdapter.DefaultAdapter;
            _bondedDevices = _manager.BondedDevices;

            
            int i = 0;

            string[] _listMAC = new string[_bondedDevices.Count];

            foreach (var item in _bondedDevices)
            {
                _listMAC[i] = item.Name  + "   -   " + item.Address;
                i++;
            }
            
            Items = new ObservableCollection<string>(_listMAC);
			
			MyListView.ItemsSource = Items;
        }



        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            

            await DisplayAlert("Item Tapped", $"An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
