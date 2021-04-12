using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMR_VCT.Models
{
    public class Patients
    {
        public int Site_id { get; set; }
        public string Nihid { get; set; }
        public string Clinic { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime DBODate { get; set; }
        public int AgeYear { get; set; }
        public int AgeMonth { get; set; }
        public string GenderStart { get; set; }
        public string GenderNow { get; set; }
        public Byte SocialSecurityType { get; set; }
        public string SocialSecurity { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherLastName { get; set; }
        public string CreationUser { get; set; }
        public string Message { get; set; }
    }
}
