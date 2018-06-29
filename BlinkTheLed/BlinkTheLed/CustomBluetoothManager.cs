using System;
using System.Collections.Generic;
using Android.Bluetooth;
using Android.Content.Res;
using Android.OS;
using Java.Util;

using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace BlinkTheLed
{

    
    interface ICustomBluetoothManager
    {
        // methods with no return
        void DoTurnOn();
        void DoTurnOff();
        void DoCancelDiscovery();
        void DoClose(IDisposable aConnectedObject);

        void DoConnectionInsecure(BluetoothDevice btDevice, UUID uuid);


        BluetoothDevice GetDevice(string macAddress);



        // methods with return type

        //  BluetoothAdapter GetMainAdapter();
        //  ICollection<BluetoothDevice> GetBondedDevices();
        //  BluetoothSocket GetSocket();


    }

    public class CustomBluetoothManager : ICustomBluetoothManager
    {

        private static BluetoothAdapter _btAdapter;
        private static ICollection<BluetoothDevice> _btBondedDevices;
        private static BluetoothSocket _btSocket;

        public static BluetoothAdapter BtAdapter { get; internal set; }
        public static ICollection<BluetoothDevice> BtBondedDevices { get; set; }
        public static BluetoothSocket BtSocket { get; set; }


        // Constructor
        public CustomBluetoothManager()
        {
            _btAdapter = BluetoothAdapter.DefaultAdapter;
            _btBondedDevices = _btAdapter.BondedDevices;

        }

        // --------------------------------------------


        static async Task Display(string title, string content, string button)
        {
            await Display(title, content, button);
        }







        //--------------------------------------------------

        public void DoTurnOn()
        {
            if (!_btAdapter.IsEnabled) _btAdapter?.Enable();
        }

        public void DoTurnOff()
        {
            if (_btAdapter.IsEnabled) _btAdapter?.Disable();
        }

        public void DoCancelDiscovery()
        {
            if (_btAdapter.IsEnabled && _btAdapter.IsDiscovering) _btAdapter?.CancelDiscovery();
        }

        public void DoClose(IDisposable aConnectedObject)
        {
            if (aConnectedObject == null) return;

            try
            {
                aConnectedObject.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public void DoConnectionInsecure(BluetoothDevice btDevice, UUID uuid)
        {
            try
            {
                _btSocket = btDevice.CreateInsecureRfcommSocketToServiceRecord(uuid);
                _btSocket.Connect();

            }
            catch (Exception e)
            {
                this.DoClose(_btSocket);
                this.DoClose(_btAdapter);
                this.DoClose(btDevice);
            }
        }

        public BluetoothDevice GetDevice(string macAddress)
        {
            return _btAdapter.GetRemoteDevice(macAddress);
        }
    }
    
}