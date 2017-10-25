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
using Tech.Classes;
using System.Threading.Tasks;

namespace Tech
{

    public class ViewHolder : Java.Lang.Object
    {

        public TextView txtPETC { get; set; }
        public TextView txtTask { get; set; }
        public TextView txtDateDeployment { get; set; }
        

    }


   public class Deployment_Adapter : BaseAdapter 
    {

        private Activity activity;
        private List<Person> persons;
        private List<tblTechDeployment> tblTechDeployment;
   



        public Deployment_Adapter(Activity activity, List<tblTechDeployment> tblTechDeployment) 
       {

           this.activity = activity;
           this.tblTechDeployment = tblTechDeployment;
       }

   

        public override int Count
        {
            get { return tblTechDeployment.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return tblTechDeployment[position].ID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.List_Deployment_Temp, parent, false);
            var txtPETC = view.FindViewById<TextView>(Resource.Id.textView1);
            var txtTask = view.FindViewById<TextView>(Resource.Id.textView2);
            var txtDateDeployment = view.FindViewById<TextView>(Resource.Id.textView3);
            var myImageview = view.FindViewById<ImageView>(Resource.Id.imageView1);
           
            var btnViewDetailed_Deployment = view.FindViewById<Button>(Resource.Id.btnViewDetailed_Deployment);
            var btnUpload_Deployment = view.FindViewById<Button>(Resource.Id.btnUpload_Deployment);

            //Click Events
            btnViewDetailed_Deployment.Click += delegate
            {

                MyPV.DeploymentId = tblTechDeployment[position].ID;                 
                Intent intent = new Intent(activity, typeof(ViewDeployment_Detailed_Activity));
                activity.StartActivity(intent);
                activity.Finish();
            };

            btnUpload_Deployment.Click += delegate
            {

              //  UploadDeployment(tblTechDeployment[position].ID);
              
            
            };

            //Display Data
            txtPETC.Text = tblTechDeployment[position].PETCNAme;
            txtTask.Text = tblTechDeployment[position].Tech_Tasks;
            myImageview.SetImageBitmap(MyPV.DecodeImage(tblTechDeployment[position].TechImage));
            txtDateDeployment.Text =  tblTechDeployment[position].Date_Deployment.ToString("MM/dd/yyyy");
            if (tblTechDeployment[position].UploadedCode != null)
            {

                txtTask.SetTextColor(Android.Graphics.Color.Gray);
            }
            return view;
        }


  
       
     
     


    }
}