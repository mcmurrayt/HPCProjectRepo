using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyDoc.Shared
{
    public class Provider
    {
        public string region { get; set; }
        public string region_code { get; set; }
        public string period { get; set; }
        public string state_fips { get; set; }
        public string county_fips { get; set; }
        public string fips { get; set; }
        public int all_providers { get; set; }
        public int all_primary_care_providers { get; set; }
        public int all_physicians { get; set; }
        public int all_primary_care_physicians { get; set; }
        public int all_nurse_practitioners { get; set; }
        public int all_primary_care_nurse_practitioners { get; set; }
        public int all_physician_assistants { get; set; }
        public int all_primary_care_physician_assistants { get; set; }
    }
}
/* 
     "region": "Colorado",
        "region_code": "CO",
        "period": "2013",
        "state_fips": "8",
        "county_fips": "1",
        "fips": "8001",
        "all_providers": "1304",
        "all_primary_care_providers": "340",
        "all_physicians": "1033",
        "all_primary_care_physicians": "229",
        "all_nurse_practitioners": "128",
        "all_primary_care_nurse_practitioners": "47",
        "all_physician_assistants": "144",
        "all_primary_care_physician_assistants": "64"
     */