using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Querying;
using LSM_Tech;
namespace RDMS_Services.Models
{
    public class RDMSRepository : IRDMSRepository
    {


       private LightSpeedContext<LightSpeedModel1UnitOfWork> Lsconn = new LightSpeedContext<LightSpeedModel1UnitOfWork>();


     
        private List<tblTechDeployment_data> tech_list = new List<tblTechDeployment_data>();


        private int _nextId = 1;

        public RDMSRepository()
        {

            //AddTech(new tblTechDeployment_data { USERNAME = "RICH", MOBILENO = "09483836995" });
            //AddTech(new tblTechDeployment_data { USERNAME = "POGI", MOBILENO = "09078081234" });
            LoadList();
          
        }

        public IEnumerable<tblTechDeployment_data> GetAll()        
        {
            return tech_list;
        }

        private void LoadConnection()
        {
            Lsconn.ConnectionString = "Data Source=192.168.1.52;Initial Catalog=RDMS_DB;Persist Security Info=True;User ID=sa;Password=1234567;Pooling=False";
            Lsconn.DataProvider = DataProvider.SqlServer2008;
            Lsconn.IdentityMethod = IdentityMethod.IdentityColumn;      
        }


        public IEnumerable<tblTechDeployment_data> GetTechID(int id)
        {
            return tech_list.Where(r=>r.ID==id).ToList();
        }


        public bool AddTech(tblTechDeployment_data tbl)
        {
            LoadConnection();
            using (LightSpeedModel1UnitOfWork work = Lsconn.CreateUnitOfWork())
            {

                TblTechDeployment mytbl = new TblTechDeployment();
                mytbl.Username = tbl.USERNAME;
                mytbl.Mobileno = tbl.MOBILENO;
                mytbl.Petcname = tbl.PETCNAME;
                mytbl.TechTasks = tbl.TECH_TASKS;
                mytbl.DateDeployment = tbl.DATE_DEPLOYMENT;
                mytbl.TasksDescription = tbl.TASKS_DESCRIPTION;
                mytbl.Longtitude = tbl.LONGTITUDE;
                mytbl.Latitude = tbl.LATITUDE;
                mytbl.Location = tbl.LOCATION;
                mytbl.UploadedCode = tbl.UPLOADED_CODE;
                mytbl.UploadedDate = DateTime.Now;
                mytbl.TechImage = tbl.TECH_IMAGE;
                mytbl.DateFiled = tbl.DATE_FILED;
                mytbl.GenCode = tbl.GEN_CODE;
                mytbl.SerialCode = tbl.SERIAL_CODE;
                mytbl.TechImage = tbl.TECH_IMAGE;
                

                if (mytbl.Errors.Count == 0)
                {
                    work.Add(mytbl);
                    work.SaveChanges();
                  
                   // LoadList();
                    tbl.ID = tech_list.Count + 1;
                    tech_list.Add(tbl);
                    return true;
                }
                else {

                    return true;
                }
                
            }

        }

        public void LoadList()
        {
            LoadConnection();
            tech_list = new List<tblTechDeployment_data>();

            using (LightSpeedModel1UnitOfWork work = Lsconn.CreateUnitOfWork())
            {
                Query sql = new Query();
                IList<TblTechDeployment> mylist = work.Find<TblTechDeployment>(sql);


                for (int i = 0; i < mylist.Count; i++)
                {
                    tblTechDeployment_data tbl = new tblTechDeployment_data();

                    tbl.ID = mylist[i].Id;
                    tbl.USERNAME = mylist[i].Username;
                    tbl.MOBILENO = mylist[i].Mobileno;
                    tbl.PETCNAME = mylist[i].Petcname;
                    tbl.TECH_TASKS = mylist[i].TechTasks;
                    tbl.DATE_DEPLOYMENT = mylist[i].DateDeployment;
                    tbl.TASKS_DESCRIPTION = mylist[i].TasksDescription;
                    tbl.LONGTITUDE = mylist[i].Longtitude;
                    tbl.LATITUDE = mylist[i].Latitude;
                    tbl.LOCATION = mylist[i].Location;
                    tbl.UPLOADED_CODE = mylist[i].UploadedCode;
                    tbl.UPLOADED_DATE = mylist[i].UploadedDate;
                    tbl.TECH_IMAGE = mylist[i].TechImage;
                    tbl.DATE_FILED = mylist[i].DateFiled;
                    tbl.GEN_CODE = mylist[i].GenCode;
                    tbl.SERIAL_CODE = mylist[i].SerialCode;

                    tech_list.Add(tbl);

                }

            }
        }

    }
}