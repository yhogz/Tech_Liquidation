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
using Tech.Classes;
using Tech.Model;

namespace Tech
{
    [Activity(Label = "RDMS Tech", MainLauncher = true, Theme = "@style/Theme.Custom")]
    public class MainMenu_Activity : Activity
    {

        Button btnM_NewDeployment;
        Button btnM_ViewDeployment;
        Button btnM_CheckConnection;
        Button btnCheckGPS;
        Button btnSignUp;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MainMenu);

            //Create Tables
            MyPV.CreateTable();

            //Initialize Buttons
            btnM_NewDeployment = FindViewById<Button>(Resource.Id.btnM_NewDeployment);
            btnM_ViewDeployment = FindViewById<Button>(Resource.Id.btnM_ViewDeployment);
            btnM_CheckConnection = FindViewById<Button>(Resource.Id.btnM_CheckConnection);
            btnCheckGPS = FindViewById<Button>(Resource.Id.btnCheckGPS);
            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);

            //Click Events
            btnM_NewDeployment.Click += btnM_NewDeployment_Click;
            btnM_ViewDeployment.Click += btnM_ViewDeployment_Click;
            btnM_CheckConnection.Click += btnM_CheckConnection_Click;
            btnCheckGPS.Click += btnCheckGPS_Click;

            List<tblTechUser> mylist = new List<tblTechUser>();
            mylist = MyPV.CheckUser();

            if (mylist.Count >0)
            {
                // do nothing
            }
            else {

                Intent intent = new Intent(this, typeof(SignUp_Activity));
                StartActivity(intent);

            }

        }

        void btnCheckGPS_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(GPS_Activity));
            StartActivity(intent);
        }

        void btnM_CheckConnection_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                RunOnUiThread(() => Toast.MakeText(this, "Connecting......", ToastLength.Long).Show());


            })).Start();

            new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                RunOnUiThread(() => MyPV.CreateTable());


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

        void btnM_ViewDeployment_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ViewDeployment_Activity));
            StartActivity(intent);
        }

        void btnM_NewDeployment_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Deployment_Activity));
            StartActivity(intent);
        }



    }
}