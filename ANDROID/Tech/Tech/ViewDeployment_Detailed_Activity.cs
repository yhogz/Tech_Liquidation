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
using SQLite;
using Tech.Model;
using Tech.Classes;
using Android.Locations;
using System.Threading.Tasks;

namespace Tech
{
    [Activity(Label = "Deployments Details", Theme = "@style/Theme.Custom")]
    public class ViewDeployment_Detailed_Activity : Activity
    {

        
        TextView lblPETC;
        TextView lblTasks;
        TextView lblDate_Deployment;
        TextView lblCoordinates;
        TextView lblTask_Description;
        ImageView img_ViewTech;

        Button btnCheckCoordinates;
        Button btnShowListDeployment;
        Button btnUploadDeployment;
        double mylongtitude;
        double mylatitude;

       // 

    protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ViewDeployment_Detailed);
            lblPETC = FindViewById<TextView>(Resource.Id.lblPETC);
            lblTasks = FindViewById<TextView>(Resource.Id.lblTasks);
            lblDate_Deployment = FindViewById<TextView>(Resource.Id.lblDate_Deployment);
            lblCoordinates = FindViewById<TextView>(Resource.Id.lblCoordinates);
            lblTask_Description = FindViewById<TextView>(Resource.Id.lblTask_Description);
            img_ViewTech = FindViewById<ImageView>(Resource.Id.img_ViewTech);
            btnCheckCoordinates = FindViewById<Button>(Resource.Id.btnCheckCoordinates);
            btnShowListDeployment = FindViewById<Button>(Resource.Id.btnShowListDeployment);
            btnUploadDeployment = FindViewById<Button>(Resource.Id.btnUploadDeployment);
            Display_Data();
          
        //Click Events
        btnCheckCoordinates.Click += btnCheckCoordinates_Click;
          //  btnShowListDeployment.Click += btnShowListDeployment_Click;
        btnShowListDeployment.Click += btnShowListDeployment_Click;
        btnUploadDeployment.Click += btnUploadDeployment_Click;


        }

    void btnUploadDeployment_Click(object sender, EventArgs e)
    {
        new System.Threading.Thread(new System.Threading.ThreadStart(() =>
        {
            RunOnUiThread(() => Toast.MakeText(this, "Saving Data", ToastLength.Long).Show());

        })).Start();

        UploadDeployment(MyPV.DeploymentId);
    }


    async void UploadDeployment(int myId)
    {

        tblTechDeployment mytbl = new tblTechDeployment();
        mytbl = MyPV.Search_byID(myId);

        TechDeploymentData.Username = mytbl.Username;
        TechDeploymentData.PETCNAme = mytbl.PETCNAme;
        TechDeploymentData.Tech_Tasks = mytbl.Tech_Tasks;
        TechDeploymentData.Date_Deployment = mytbl.Date_Deployment;
        TechDeploymentData.Tasks_Description = mytbl.Tasks_Description;
        TechDeploymentData.Longtitude = mytbl.Longtitude;
        TechDeploymentData.Latitude = mytbl.Latitude;
        TechDeploymentData.Date_Filed = mytbl.Date_Filed;
        TechDeploymentData.GenCode = mytbl.GenCode;
        TechDeploymentData.SerialCode = mytbl.SerialCode;
        TechDeploymentData.UploadedCode = MyPV.GetRandomString(10);
        TechDeploymentData.TechImage = mytbl.TechImage;


        //bool stat = RDMS_Functions.Save_TechDeployment();
        Task<bool> mystat = My_APIFunctions.Save_TechDeployment();
        bool apistat = await mystat;
        if (apistat == true)
        {
            MyPV.Update_UploadedCode(TechDeploymentData.GenCode, TechDeploymentData.UploadedCode);
            new AlertDialog.Builder(this).SetMessage("New Deployment Successfully Uploaded!").SetTitle("Server Confirmation").Show();

        }
        else
        {
            new AlertDialog.Builder(this).SetMessage("Can't Save! Make sure you are connected to server!").SetTitle("Error: Server Confirmation").Show();
        }

    }
     

    void btnShowListDeployment_Click(object sender, EventArgs e)
    {
        Intent intent = new Intent(this, typeof(ViewDeployment_Activity));
        StartActivity(intent);
        this.Finish();
    }

   

    void btnCheckCoordinates_Click(object sender, EventArgs e)
 {    
     try
     {
         GetLocation();
     }
     catch (Exception ex) 
     {
         new AlertDialog.Builder(this).SetMessage("Make sure you are connected to internet!").SetTitle("Error").Show();
     }
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

         string myaddress = "";
         StringBuilder deviceAddress = new StringBuilder();
         for (int i = 0; i < address.MaxAddressLineIndex; i++)
         {
             myaddress = myaddress +  address.GetAddressLine(i).ToString();
         }

         new AlertDialog.Builder(this).SetMessage(myaddress).SetTitle("Location").Show();
     }
     else
     {
         new AlertDialog.Builder(this).SetMessage("Make sure you are connected to internet!").SetTitle("Error").Show();
     }
 }

     public void Display_Data()
        {

            var db = new SQLiteConnection(MyPV.DBConnections);
            tblTechDeployment tbl = new tblTechDeployment();
            tbl = db.Table<tblTechDeployment>().Where(r => r.ID == MyPV.DeploymentId).FirstOrDefault();

            if (tbl != null) {

                lblPETC.Text = "PETC : " +  tbl.PETCNAme;
                lblTasks.Text = "Task : " + tbl.Tech_Tasks.ToString();
                lblDate_Deployment.Text = "Date of Deployment: " + tbl.Date_Deployment.ToString("MM/dd/yyyy");
                lblCoordinates.Text ="Coordinates : " + "Long= " + tbl.Longtitude + "  " + "Lat= " + tbl.Latitude;
                lblTask_Description.Text = "Task Description : " + tbl.Tasks_Description.ToString();
                img_ViewTech.SetImageBitmap(MyPV.DecodeImage(tbl.TechImage));
                mylatitude = Convert.ToDouble(tbl.Latitude);
                mylongtitude =Convert.ToDouble(tbl.Longtitude);

                if (tbl.UploadedCode != null) {
                    btnUploadDeployment.Visibility = ViewStates.Gone;
                }
            }
        
        }

    }
}