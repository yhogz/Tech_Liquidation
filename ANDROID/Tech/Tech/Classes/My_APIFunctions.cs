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
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Tech.Classes
{
   public class My_APIFunctions
    {


       private static string MyURI = "http://121.58.242.100:7034/api/TechDeployment";
       public static bool api_status;

       public async static Task<bool> Save_TechDeployment()
       {
           string URI = MyURI;
           tblTechDeployment_data tbl = new tblTechDeployment_data();
           tbl.USERNAME = TechDeploymentData.Username;
           tbl.MOBILENO = TechDeploymentData.MobileNo;
           tbl.PETCNAME = TechDeploymentData.PETCNAme;
           tbl.TECH_TASKS = TechDeploymentData.Tech_Tasks;
           tbl.DATE_DEPLOYMENT = TechDeploymentData.Date_Deployment;
           tbl.TASKS_DESCRIPTION = TechDeploymentData.Tasks_Description;
           tbl.LONGTITUDE = TechDeploymentData.Longtitude;
           tbl.LATITUDE = TechDeploymentData.Latitude;
           tbl.LOCATION = TechDeploymentData.Location;
           tbl.UPLOADED_CODE = TechDeploymentData.UploadedCode;
           tbl.UPLOAD_DATE = DateTime.Now;  
           tbl.TECH_IMAGE = TechDeploymentData.TechImage;
           tbl.GEN_CODE = TechDeploymentData.GenCode;   
           tbl.SERIAL_CODE = TechDeploymentData.SerialCode;
           using (var client = new HttpClient())
           {
               var serializedProduct = JsonConvert.SerializeObject(tbl);
               var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
               var result = await client.PostAsync(URI, content);

               if (result.StatusCode == System.Net.HttpStatusCode.OK)
               {
                   api_status = true;
               }
               else
               {
                   api_status = false;
               }

               return api_status;
           }
       }
    }
        
    public class tblTechDeployment_data
    {
        public long ID { get; set; }
        public string USERNAME { get; set; }
        public string MOBILENO { get; set; }
        public string PETCNAME { get; set; }
        public string TECH_TASKS { get; set; }
        public DateTime? DATE_DEPLOYMENT { get; set; }
        public string TASKS_DESCRIPTION { get; set; }
        public string LONGTITUDE { get; set; }
        public string LATITUDE { get; set; }
        public string LOCATION { get; set; }
        public string UPLOADED_CODE { get; set; }
        public DateTime? UPLOAD_DATE { get; set; }
        public byte[] TECH_IMAGE { get; set; }
        public DateTime? DATE_FILED { get; set; }
        public string GEN_CODE { get; set; }
        public string SERIAL_CODE { get; set; }
    }
}