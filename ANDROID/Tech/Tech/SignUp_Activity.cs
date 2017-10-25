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
using Tech.Model;
using SQLite;
using Tech.Classes;
using Android.Telephony;

namespace Tech
{
    [Activity(Label = "Sign Up", Theme = "@style/Theme.Custom")]
    public class SignUp_Activity : Activity
    {

        EditText txtFullname;
        EditText txtUsername;
        EditText txtMobileNo;
        EditText txtSerialcode;
        Button btnRegister;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SignUp);

            txtFullname = FindViewById<EditText>(Resource.Id.txtFullname);
            txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            txtMobileNo = FindViewById<EditText>(Resource.Id.txtMobileNo);
            txtSerialcode = FindViewById<EditText>(Resource.Id.txtSerialcode);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);


            btnRegister.Click += btnRegister_Click;


            txtMobileNo.Text = Get_PhoneNumber();         
            txtSerialcode.Text = DateTime.Now.ToString("MMddyyyyHHmmss") + MyPV.GetRandomString(4); 



        }

        void btnRegister_Click(object sender, EventArgs e)
        {

            

            try {

                new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    RunOnUiThread(() => Toast.MakeText(this, "Saving Data", ToastLength.Long).Show());

                })).Start();

                var mydb = new SQLiteConnection(MyPV.DBConnections);
                tblTechUser mytbl = new tblTechUser();
                mytbl.Username = txtUsername.Text;
                mytbl.Fullname = txtFullname.Text;
                mytbl.MobileNo = txtMobileNo.Text;
                mytbl.Serialcode = DateTime.Now.ToString("MMddyyyyHHmmss") + MyPV.GetRandomString(10);
                mytbl.DateRegister = DateTime.Now;
                mydb.Insert(mytbl);

                new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    RunOnUiThread(() => Toast.MakeText(this, "Data Successfully Saved!", ToastLength.Long).Show());

                })).Start();

            }
            catch (Exception ex) 
            {
            
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
            }
        
        }


        public string Get_PhoneNumber()
        {

            TelephonyManager mTelephonyMgr;

            mTelephonyMgr = (TelephonyManager)GetSystemService(TelephonyService);

            var Number = mTelephonyMgr.Line1Number;

            return Number;

        }
    }
}