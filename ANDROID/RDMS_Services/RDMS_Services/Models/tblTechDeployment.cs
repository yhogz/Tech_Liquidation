using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RDMS_Services.Models
{
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
        public DateTime? UPLOADED_DATE { get; set; }
        public byte[] TECH_IMAGE { get; set; }
        public DateTime? DATE_FILED { get; set; }
        public string GEN_CODE { get; set;}
        public string SERIAL_CODE { get; set; }

    }
}