using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Tech.Classes;

namespace Tech
{
    [Activity(Label = "Tech", Icon = "@drawable/icon", Theme = "@style/Theme.Custom")]
    public class MainActivity : Activity
    {
   
        Button btnViewDeployments;
        Button btnNewDeployment;
        Button btnCheckConnection;
        Button button1;
        Button btnGPS;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            MyPV.CreateTable();

            //Window.SetNavigationBarColor(Android.Graphics.Color.Red);

            // Get our button from the layout resource,
            // and attach an event to it

            btnViewDeployments = FindViewById<Button>(Resource.Id.btnViewDeployments);
            btnNewDeployment = FindViewById<Button>(Resource.Id.btnNewDeployment);
            btnCheckConnection = FindViewById<Button>(Resource.Id.btnCheckConnection);
            button1 = FindViewById<Button>(Resource.Id.button1);
            btnGPS = FindViewById<Button>(Resource.Id.btnGPS);


            btnViewDeployments.Click += btnViewDeployments_Click;
            btnNewDeployment.Click += btnNewDeployment_Click;
            btnCheckConnection.Click += btnCheckConnection_Click;
            button1.Click += button1_Click;
            btnGPS.Click += btnGPS_Click;

        }

        void btnGPS_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(GPS_Activity));
            StartActivity(intent);
        }

        void button1_Click(object sender, EventArgs e)
        {


            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_SignIn mydialog = new dialog_SignIn();
            mydialog.Show(transaction, "Sign In");

        }

        void btnCheckConnection_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                RunOnUiThread(() => Toast.MakeText(this, "Connecting......", ToastLength.Long).Show());
          
            
            })).Start();

            new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                RunOnUiThread(() => MyPV.CreateTable() );


            })).Start();

            bool status = RDMS_Functions.connect_server();

            if (status == true)
            {
                //btnConnect.Text = "Connected!";
                //Toast.MakeText(this, "Connected", ToastLength.Long).Show();
                new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    RunOnUiThread(() => Toast.MakeText(this, "Connected", ToastLength.Long).Show());
                })).Start();

            }
            else
            {
                new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    RunOnUiThread(() => Toast.MakeText(this, "Can't Connect, Pls. Try Again!", ToastLength.Long).Show());
                })).Start();

            }


           
        }

        void btnNewDeployment_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Deployment_Activity));
            StartActivity(intent);
        }

        void btnViewDeployments_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(ViewDeployment_Activity));
            StartActivity(intent);
        }


        


    }
}

