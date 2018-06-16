using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlinkTheLed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			InitializeComponent ();
		}

	    private async void Bluetooth_Options(object sender, System.EventArgs e)
	    {
	        await Navigation.PushAsync(new BlinkTheLed.BluetoothPage());

	    }

        private void Button_One(object sender, EventArgs e)
	    {
	       
	    }

	    private void Button_Two(object sender, EventArgs e)
	    {
	        
	    }

	    private void Button_Three(object sender, EventArgs e)
	    {
	        
	    }
	}
}