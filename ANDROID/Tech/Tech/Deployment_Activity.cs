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
using SQLite;
using Tech.Model;
using Android.Provider;
using Android.Content.PM;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using Java.IO;
using Android.Graphics;
using Android.Util;
using Android.Locations;
using System.Threading.Tasks;


namespace Tech
{
    public static class App
    {
        public static File _file;

        public static File _dir;
        public static Android.Graphics.Bitmap bitmap;
       
    }



    [Activity(Label = "Create Deployment", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Deployment_Activity : Activity
    {
      
        Spinner spn_PETC;
        Spinner spn_Tasks;
        EditText txtTasksDescription;
        Button btnDateDeployment;
        Button btnCaptureImage;
        Button btnSaveDeployment;
        ImageView _imageView;
        List<tblTechUser> myuser;
        string staterror = "0";
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Deployment);
            //MyPV.GetMyLocation();
            var mydb = new SQLiteConnection(MyPV.DBConnections);
            //mydb.DeleteAll<tblTechDeployment>();

            // Create your application here            
            spn_PETC = FindViewById<Spinner>(Resource.Id.spn_PETC);
            spn_Tasks = FindViewById<Spinner>(Resource.Id.spn_Tasks);
            txtTasksDescription = FindViewById<EditText>(Resource.Id.txtTasksDescription);
            btnDateDeployment = FindViewById<Button>(Resource.Id.btnDateDeployment);
            btnCaptureImage = FindViewById<Button>(Resource.Id.btnCaptureImage);
            btnSaveDeployment = FindViewById<Button>(Resource.Id.btnSaveDeployment);
            _imageView = FindViewById<ImageView>(Resource.Id.imageView1);


            Load_PETC();
            Load_Tasks();
            myuser = MyPV.CheckUser();
          

            spn_PETC.Focusable = true;
            spn_PETC.FocusableInTouchMode = true;
            spn_PETC.RequestFocus();

            btnDateDeployment.Click += btnDateDeployment_Click;
            btnSaveDeployment.Click += btnSaveDeployment_Click;
            btnCaptureImage.Click += btnCaptureImage_Click;
                

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

            }


        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(App._file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display
            // Loading the full sized image will consume to much memory 
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = _imageView.Height;
            App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);
            //App.bitmap = App._file.Path
            if (App.bitmap != null)
            {
                _imageView.SetImageBitmap(App.bitmap);
                App.bitmap = null;
            }

            // Dispose of the Java side bitmap.
            GC.Collect();
        }

        void btnCaptureImage_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(MediaStore.ActionImageCapture);

            intent.PutExtra("android.intent.extras.CAMERA_FACING", 1);

            App._file = new File(App._dir, String.Format("RichMyPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));

            StartActivityForResult(intent, 0);
        }

        private void CreateDirectoryForPictures()
        {
            App._dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "CameraAppDemo");
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

      async void btnSaveDeployment_Click(object sender, EventArgs e)
        {


            staterror = "0";
            if (spn_PETC.SelectedItem.ToString() == "*SELECT PETC Name")
            {
                Toast.MakeText(this, "Please Select PETC Name", ToastLength.Short).Show();
                spn_PETC.RequestFocus();
                staterror = "1";
                return;
            }

            if (spn_Tasks.SelectedItem.ToString() == "*SELECT TASK")
            {
                Toast.MakeText(this, "Please Select Task", ToastLength.Short).Show();
                spn_PETC.RequestFocus();
                staterror = "1";
                return;
            }

            if (txtTasksDescription.Text.Trim().Length == 0)
            {
                txtTasksDescription.Error = "Please Insert Task Description";
                txtTasksDescription.RequestFocus();
                staterror = "1";
                return;
            }

            if (btnDateDeployment.Text.ToUpper() == "SELECT DATE OF DEPLOYMENT")
            {
                Toast.MakeText(this, "Please Select Date of Deployment", ToastLength.Short).Show();
                btnDateDeployment.RequestFocus();
                staterror = "1";
                return;
            }

          

            bool hasDrawable = (_imageView.Drawable != null);
            if (hasDrawable)
            {
                // imageView has an image in it
            }
            else
            {
                Toast.MakeText(this, "Please Capture an Image", ToastLength.Short).Show();
                btnCaptureImage.RequestFocus();
                staterror = "1";
                return;
            }


            if (staterror == "0") 
            {
                new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    RunOnUiThread(() => Toast.MakeText(this, "Saving Data", ToastLength.Long).Show());

                })).Start();


                bool stat = await MyPV.GetMyLocation();

                if (stat == false)
                {

                    Toast.MakeText(this, "Make sure your GPS was connected!", ToastLength.Long).Show();
                }
                else
                {
                    Save_Deployment();
                }  
            }

            

        }


       async void Save_Deployment()
        {

            if (MyPV.GPS_latitude != 0)
            {

                //SAVE DEPLOYMENT
                try
                {
                    var mydb = new SQLiteConnection(MyPV.DBConnections);
                    tblTechDeployment mytbl = new tblTechDeployment();
                    mytbl.PETCNAme = spn_PETC.SelectedItem.ToString();
                    mytbl.Tech_Tasks = spn_Tasks.SelectedItem.ToString();
                    mytbl.Date_Deployment = Convert.ToDateTime(btnDateDeployment.Text);
                    mytbl.Tasks_Description = txtTasksDescription.Text;
                    mytbl.Username = myuser[0].Username;
                    mytbl.TechImage = MyPV.ConvertImage(_imageView);
                    mytbl.Longtitude = MyPV.GPS_longtitude.ToString();
                    mytbl.Latitude = MyPV.GPS_latitude.ToString();
                    mytbl.Date_Filed = DateTime.Now;
                    mytbl.GenCode = DateTime.Now.ToString("MMddyyyyHHmmss") +  MyPV.GetRandomString(10);
                    mytbl.SerialCode = myuser[0].Serialcode;
                    mytbl.MobileNo = myuser[0].MobileNo;
                    
                    mydb.Insert(mytbl);

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
                    TechDeploymentData.TechImage = mytbl.TechImage;
                    TechDeploymentData.MobileNo = mytbl.MobileNo;
                    TechDeploymentData.UploadedCode =  DateTime.Now.ToString("MMddyyyyHHmmss") + MyPV.GetRandomString(10);

                  //  bool stat = RDMS_Functions.Save_TechDeployment();     
                    Task<bool> mystat = My_APIFunctions.Save_TechDeployment();
                    bool apistat = await mystat;                  
                    if (apistat == true)
                    {

                        MyPV.Update_UploadedCode(TechDeploymentData.GenCode, TechDeploymentData.UploadedCode);
                        new AlertDialog.Builder(this).SetMessage("New Deployment Successfully Saved!").SetTitle("Server Confirmation").Show();
                        Clear_Fields();
                    }
                    else {

                        new AlertDialog.Builder(this).SetMessage("New Deployment Successfully Saved!").SetTitle("Local Confirmation").Show();
                    }                    
              
                }
                catch (Exception ex)
                {
                    //new AlertDialog.Builder(this).SetMessage(ex.Message).SetTitle("Error").Show();
                    Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
                }

            }
            else
            {
                new AlertDialog.Builder(this).SetMessage("Check if GPS is open").SetTitle("Error").Show();

            }

        }

        void btnDateDeployment_Click(object sender, EventArgs e)
        {
            //SELECT DATE

            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate(DateTime time)
            {
                btnDateDeployment.Text = time.ToShortDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        void Clear_Fields()
        {

            txtTasksDescription.Text = "";
            btnDateDeployment.Text = "Select Date of Deployment";
            _imageView.SetImageBitmap(null);
            spn_PETC.SetSelection(0);
            spn_Tasks.SetSelection(0);
        }

        public void Load_PETC()
        {

            var petc_adapter = ArrayAdapter.CreateFromResource(
                     this, Resource.Array.petc_array, Android.Resource.Layout.SimpleSpinnerItem);
            petc_adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spn_PETC.Adapter = petc_adapter;
        }

        public void Load_Tasks()
        {
            var tasks_adapter = ArrayAdapter.CreateFromResource(
                      this, Resource.Array.tasks_array, Android.Resource.Layout.SimpleSpinnerItem);
            tasks_adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spn_Tasks.Adapter = tasks_adapter;


        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            App._file = new File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));
            StartActivityForResult(intent, 0);
        }


     

      
    }

    public static class BitmapHelpers
    {
        public static Bitmap LoadAndResizeBitmap(this string fileName, int width, int height)
        {
            // First we get the the dimensions of the file on disk
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            // Next we calculate the ratio that we need to resize the image by
            // in order to fit the requested dimensions.
            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outHeight > height || outWidth > width)
            {
                inSampleSize = outWidth > outHeight
                                   ? outHeight / height
                                   : outWidth / width;
            }

            // Now we will load the image and have BitmapFactory resize it for us.
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            return resizedBitmap;
        }
    }

}