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
using Android.Locations;
using System.Threading.Tasks;


namespace Tech
{
    [Activity(Label = "Deployments", Theme = "@style/Theme.Custom")]
    public class ViewDeployment_Activity : Activity
    {
        ListView listViewer;
        TextView lblTotalNotUploaded;
           

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ViewDeployment);

            listViewer = FindViewById<ListView>(Resource.Id.listView1);
            lblTotalNotUploaded = FindViewById<TextView>(Resource.Id.lblTotalNotUploaded);
      
            Display_Deployments();

            lblTotalNotUploaded.Text = "No. of Needed to Upload : " + MyPV.Count_NeedtoUpload();
        
        }
        
        
       
   
        public void Display_Deployments()
        {

            //List<Person> lstSource = new List<Person>();
            List<tblTechDeployment> lstSource = new List<tblTechDeployment>();

            var db = new SQLiteConnection(MyPV.DBConnections);
            List<tblTechDeployment> list = new List<tblTechDeployment>();
            list = db.Table<tblTechDeployment>().OrderByDescending(r=>r.Date_Filed).ToList();

            var adapter = new Deployment_Adapter(this, list);
            listViewer.Adapter = adapter;
           
         }

     
    }
}