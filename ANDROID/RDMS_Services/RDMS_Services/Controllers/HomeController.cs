using RDMS_Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RDMS_Services.Controllers
{
    public class HomeController : Controller
    {

        static readonly IRDMSRepository repository = new RDMSRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Deployments()
        {
            List<tblTechDeployment_data> mylist = new List<tblTechDeployment_data>();

            return View(repository.GetAll());
        }
    }
}
