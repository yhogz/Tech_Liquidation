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
using System.IO;
using Tech.Model;
using SQLite;
using Plugin.Geolocator;
using System.Threading.Tasks;
using Android.Telephony;

using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using Android.Content.PM;
using System.Drawing;

namespace Tech.Classes
{

    //My Public Variable
    public class MyPV
    {

        public static string DBConnections = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TECH_DB.db3");
        public static SQLiteConnection mydb = new SQLiteConnection(DBConnections);
        public static double GPS_longtitude;
        public static double GPS_latitude;

        public static int DeploymentId;
        public static string DeploymentCode;

        public static bool CreateTable()
        {
            try
            {
                mydb.CreateTable<tblTechDeployment>();
                mydb.CreateTable<tblTechUser>();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }

        }

        public static byte[] ConvertImage(ImageView myimage)
        {
            Android.Graphics.Bitmap mybitmap;   
            myimage.BuildDrawingCache(true);
            mybitmap = myimage.GetDrawingCache(true);
            MemoryStream stream = new MemoryStream();
            mybitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 90, stream);
            byte[] bitmapdata = stream.ToArray();
            return bitmapdata;
        }



       
        public static Android.Graphics.Bitmap DecodeImage(byte[] mybyte)
        {

           
            try
            {
                Android.Graphics.Bitmap bitmap = Android.Graphics.BitmapFactory.DecodeByteArray(mybyte, 0, mybyte.Length);

                return bitmap;

            }
            catch (Exception ex) 
            {

                return null;
            }

        }

        public static async Task<bool> GetMyLocation()
        {        
            try 
            {
                GPS_longtitude = 0;
                GPS_latitude = 0;

                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 70;

                var position = await locator.GetPositionAsync(10000);
                GPS_longtitude = position.Longitude;
                GPS_latitude = position.Latitude;
                return true;

            }catch(Exception ex)
            {              
                return false;   
            }

        }
        
        public static int Count_NeedtoUpload()
        {
            var db = new SQLiteConnection(MyPV.DBConnections);
            List<tblTechDeployment> list = new List<tblTechDeployment>();
            list = db.Table<tblTechDeployment>().Where(r=>r.UploadedCode == (null)).ToList();

            return list.Count;      
        }

        private static Random random = new Random();
        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static tblTechDeployment Search_byID(int myid)
        {

            var db = new SQLiteConnection(MyPV.DBConnections);
            tblTechDeployment tbl = new tblTechDeployment();
            tbl = db.Table<tblTechDeployment>().Where(r => r.ID == myid).FirstOrDefault();

            return tbl;  


        }

        public static bool Update_UploadedCode(string gencode, string UploadedCode)
        {
         try 
            {
                var db = new SQLiteConnection(MyPV.DBConnections);
                tblTechDeployment tbl = new tblTechDeployment();
                tbl = db.Table<tblTechDeployment>().Where(r => r.GenCode.Equals(gencode)).FirstOrDefault();

                tbl.UploadedCode = UploadedCode;
                tbl.UploadedDate = DateTime.Now;
                db.Update(tbl);
                return true;

            }
            catch (Exception ex) {
                return false;
            }

        }

        public static List<tblTechUser> CheckUser()
        {
            var db = new SQLiteConnection(MyPV.DBConnections);
            List<tblTechUser> list = new List<tblTechUser>();
            list = db.Table<tblTechUser>().ToList();
            return list;  

        }

       


    }
}