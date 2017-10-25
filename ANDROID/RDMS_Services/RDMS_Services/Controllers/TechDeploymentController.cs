using RDMS_Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Querying;
using LSM_Tech;
namespace RDMS_Services.Controllers
{
    public class TechDeploymentController : ApiController
    {


        static readonly IRDMSRepository repository = new RDMSRepository();

        public IEnumerable<tblTechDeployment_data> GetAllDeployments()
        {
            return repository.GetAll();
        }

        public IEnumerable<tblTechDeployment_data> GetTechID(int Id)
        {

            return repository.GetTechID(Id);   
        }

        public bool AddTech(tblTechDeployment_data tbl)
        {

            return repository.AddTech(tbl);

        }
    
     
       
    }
}
