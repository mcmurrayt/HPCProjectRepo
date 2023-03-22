using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPC_Project.Shared
{
    internal class OBHCProvider
    {
        public string region { get; set; }
        public string region_code { get; set; }
        public string period { get; set; }
        public string state_fips { get; set; }
        public string county_fips { get; set; }
        public string fips { get; set; }
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
}
