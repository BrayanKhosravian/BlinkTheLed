using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Bluetooth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlinkTheLed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{

		private BluetoothSocket _btSocket = null;

	    private Stream _outStream;

		public WelcomePage ()
		{
			InitializeComponent ();
		    _btSocket = ShowPairedListView._socket;
		}

		private async void Bluetooth_Options(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new BlinkTheLed.BluetoothPage());

		}

		private void Button_One(object sender, EventArgs e)
		{
			try
			{
			   _outStream = ShowPairedListView._socket.OutputStream;
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
				throw;
			}

			var msg1 = new Java.Lang.String("1");
			byte[] msgBuffer = msg1.GetBytes();

		    byte[] i = new Java.Lang.String("1").GetBytes();


			try
			{
		        _outStream.Write(i, 0, i.Length);
			   
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void Button_Two(object sender, EventArgs e)
		{
		    try
		    {
		        _outStream = ShowPairedListView._socket.OutputStream;
		    }
		    catch (Exception exception)
		    {
		        Console.WriteLine(exception);
		        throw;
		    }

		    var msg1 = new Java.Lang.String("1");
		    byte[] msgBuffer = msg1.GetBytes();

		    byte[] i = new Java.Lang.String("1").GetBytes();


		    try
		    {
		        _outStream.Write(i, 0, i.Length);

		    }
		    catch (Exception)
		    {

		        throw;
		    }
        }

		private void Button_Three(object sender, EventArgs e)
		{
			
		}
	}
}