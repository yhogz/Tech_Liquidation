using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Querying;
using LSM_Tech;
namespace RDMS_Services.Models
{
    interface IRDMSRepository
    {


        IEnumerable<tblTechDeployment_data> GetAll();
        IEnumerable<tblTechDeployment_data> GetTechID(int id);
        bool AddTech(tblTechDeployment_data tbl);
       
       



        //IEnumerable<tblTechDeployment_data> GetAll();
        //IEnumerable<tblTechDeployment_data> GetTech(int id);
        //tblTechDeployment_data AddTech(tblTechDeployment_data tbl);
    }
}
