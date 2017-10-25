using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using RestSharp;
namespace ClientTest_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {

            var url = "http://192.168.1.194:7030/AppServices/";
            JObject json = new JObject();
            json.Add("Firstname", "Rich");
            json.Add("Lastname", "Pogi");
            json.Add("Age", "26");
            json.Add("Gender", "Male");

            WebClient c = new WebClient();
            c.Headers[HttpRequestHeader.ContentType] = "application/json";
            string result = c.UploadString(url + "addPerson", json.ToString(Newtonsoft.Json.Formatting.None, null));
            JToken response = JToken.Parse(result);
            bool success = response.ToObject<bool>();
            MessageBox.Show(success.ToString());


        }

        private void button1_Click(object sender, EventArgs e)
        {

        
            var url = "http://192.168.1.194:7030/AppServices/";
            JObject json = new JObject();
            json.Add("Username", "Rich");
            json.Add("MobileNo", "09483836995");
            json.Add("PETCNAme", "RDMS Functional Testing");
            json.Add("Tech_Tasks", "Format PC");
            json.Add("Date_Deployment", DateTime.Now);
            json.Add("Tasks_Description", "Format PC");
            json.Add("Longtitude", "14.001");
            json.Add("Latitude", "121.123");
            json.Add("Location", "");
            json.Add("UploadedCode", "");
            json.Add("Date_Filed", "2/2/2017");
            json.Add("GenCode", "");
            json.Add("SerialCode", "");



            WebClient c = new WebClient();
            c.Headers[HttpRequestHeader.ContentType] = "application/json";
            string result = c.UploadString(url + "SaveTechDeployment", json.ToString(Newtonsoft.Json.Formatting.None, null));
            JToken response = JToken.Parse(result);
          

            //bool success = response.ToObject<bool>();
            bool success = response.HasValues;
            MessageBox.Show(success.ToString());

        }


        private void btnSendPicture_Click(object sender, EventArgs e)
        {
            var url = "http://192.168.1.194:7030/AppServices/";
            JObject json = new JObject();
            json.Add("mybyte", ImageToByte(pictureBox1.Image));
    

            byte[] mypic = ImageToByte(pictureBox1.Image);

            WebClient c = new WebClient();
            c.Headers[HttpRequestHeader.ContentType] = "application/json";
            string result = c.UploadString(url + "UploadImage", json.ToString(Newtonsoft.Json.Formatting.None, null));
           // var result = c.UploadData(url + "UploadImage", mypic);
          
            //JToken response = JToken.Parse(result);
            //bool success = response.ToObject<bool>();
            //MessageBox.Show(success.ToString());







        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

     
    }
}
