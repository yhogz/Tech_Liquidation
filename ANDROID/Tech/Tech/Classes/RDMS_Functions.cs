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
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;


namespace Tech.Classes
{
   public class RDMS_Functions
    {

    

        // private static string myurl = "http://192.168.1.194:7030/AppServices/";
        private static string myurl = "http://192.168.1.53:53/AppServices/";

        public static bool connect_server()
        {
            try
            {
                var url = "http://192.168.1.194:7030/AppServices/";
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest();
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;
                request.Resource = "checkConn";
                var result = client.Execute<bool>(request);
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    bool cty = result.Data;
                    return cty;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Save_TechDeployment()
        {

            var url = "http://192.168.1.194:7030/AppServices/";
            JObject json = new JObject();
            json.Add("Username", TechDeploymentData.Username);
            json.Add("MobileNo", TechDeploymentData.MobileNo);
            json.Add("PETCNAme", TechDeploymentData.PETCNAme);
            json.Add("Tech_Tasks", TechDeploymentData.Tech_Tasks);
            json.Add("Date_Deployment", TechDeploymentData.Date_Deployment);
            json.Add("Tasks_Description", TechDeploymentData.Tasks_Description);
            json.Add("Longtitude", TechDeploymentData.Longtitude);
            json.Add("Latitude", TechDeploymentData.Latitude);
            json.Add("Location", TechDeploymentData.Location);
            json.Add("UploadedCode", TechDeploymentData.UploadedCode);
            json.Add("Date_Filed", DateTime.Now);
            json.Add("GenCode", TechDeploymentData.GenCode);    
            json.Add("SerialCode", TechDeploymentData.SerialCode);
            json.Add("TechImage", TechDeploymentData.TechImage);

            WebClient c = new WebClient();
            
            c.Headers[HttpRequestHeader.ContentType] = "application/json";
            string result = c.UploadString(url + "SaveTechDeployment", json.ToString(Newtonsoft.Json.Formatting.None, null));
            JToken response = JToken.Parse(result);
            //bool success = response.ToObject<bool>();
            bool stat = response.HasValues;
            return stat;
        }

    }

   public class TechDeploymentData
   {      
            public static string Username { get; set; }
            public static string MobileNo { get; set; }
            public static string PETCNAme { get; set; }
            public static string Tech_Tasks { get; set; }
            public static DateTime Date_Deployment { get; set; }
            public static string Tasks_Description { get; set; }
            public static string Longtitude { get; set; }
            public static string Latitude { get; set; }
            public static string Location { get; set; }
            public static string UploadedCode { get; set; }
            public static string UploadedDate { get; set; }
            public static byte[] TechImage { get; set; }
            public static DateTime Date_Filed { get; set; }
            public static string GenCode { get; set; }
            public static string SerialCode { get; set; }   
   }

  
}