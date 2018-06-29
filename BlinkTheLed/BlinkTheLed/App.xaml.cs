using System;
using Android.Bluetooth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


// http://www.androidcodec.com/xamarin-bluetooth-example-android/
// https://developer.xamarin.com/api/type/Android.Bluetooth.BluetoothAdapter/
// https://developer.android.com/guide/topics/connectivity/bluetooth



// WICHTIG !!!!!!!!!!!!!!!!!!!
// http://alejandroruizvarela.blogspot.com/2014/01/bluetooth-arduino-xamarinandroid.html?m=1

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace BlinkTheLed
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new WelcomePage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
