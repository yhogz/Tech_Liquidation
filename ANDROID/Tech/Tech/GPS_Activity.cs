using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;
using Plugin.Geolocator;
using System.Threading.Tasks;

namespace Tech
{
    [Activity(Label = "GPS_Activity")]
    public class GPS_Activity : Activity
    {

        LocationManager locMgr;
        string tag = "MainActivity";
        Button button;
        TextView latitude;
        TextView longitude;
        TextView provider;
        Button btnGetAddress;
        TextView txtAddress;
        double mylongtitude;
        double mylatitude;
        Button btnMaps;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GPS);
            button = FindViewById<Button>(Resource.Id.myButton);
            latitude = FindViewById<TextView>(Resource.Id.latitude);
            longitude = FindViewById<TextView>(Resource.Id.longitude);
            provider = FindViewById<TextView>(Resource.Id.provider);
            btnGetAddress = FindViewById<Button>(Resource.Id.btnGetAddress);
            txtAddress = FindViewById<TextView>(Resource.Id.txtAddress);
            btnMaps = FindViewById<Button>(Resource.Id.btnMaps);
            // Create your application here

            button.Click += button_Click;
            btnGetAddress.Click += btnGetAddress_Click;
        }

        void btnGetAddress_Click(object sender, EventArgs e)
        {
            GetLocation();
        }

       async void button_Click(object sender, EventArgs e)
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(10000);

            latitude.Text = position.Latitude.ToString();
            longitude.Text = position.Longitude.ToString();

            mylatitude = position.Latitude;
            mylongtitude = position.Longitude;
        }



       async void GetLocation()
       {
           Address address = await ReverseGeocodeCurrentLocation();
           DisplayAddress(address);
       }

       async Task<Address> ReverseGeocodeCurrentLocation()
       {
           Geocoder geocoder = new Geocoder(this);
           IList<Address> addressList =
               await geocoder.GetFromLocationAsync(mylatitude, mylongtitude, 10);

           Address address = addressList.FirstOrDefault();
           return address;
       }

       void DisplayAddress(Address address)
       {
           if (address != null)
           {
               StringBuilder deviceAddress = new StringBuilder();
               for (int i = 0; i < address.MaxAddressLineIndex; i++)
               {
                   //txtAddress.AppendLine(address.GetAddressLine(i));
                   //txtAddress.Append(address.GetAddressLine(i));
                   txtAddress.Text += address.GetAddressLine(i).ToString() + " ";
               }
               // Remove the last comma from the end of the address.
               //txtAddress.Text = deviceAddress.ToString();
           }
           else
           {
               txtAddress.Text = "Unable to determine the address. Try again in a few minutes.";
           }
       }
    }
}