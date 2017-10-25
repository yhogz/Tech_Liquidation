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

namespace Tech.Model
{
   public class tblTechDeployment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public string MobileNo { get; set; }
        public string PETCNAme { get; set; }
        public string Tech_Tasks { get; set; }
        public DateTime Date_Deployment { get; set; }
        public string Tasks_Description { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public string Location { get; set; }
        public string UploadedCode { get; set; }
        public DateTime UploadedDate { get; set; }
        public byte[] TechImage { get; set; }
        public DateTime Date_Filed { get; set; }
        public string GenCode { get; set; }
        public string SerialCode { get; set; }
    }

   public class tblTechUser
   {

       [PrimaryKey, AutoIncrement]
       public int ID { get; set; }
       public string Username { get; set; }
       public string Fullname { get; set; }
       public string MobileNo { get; set; }
       public string Serialcode { get; set; }
       public DateTime DateRegister { get; set; }

   }


}