using Microsoft.AspNetCore.Identity;

namespace FindMyDoc.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dob { get; set; }
        public string address { get; set; }
        public long insuranceNum { get; set; }
        public long fips { get; set; }
        public string gender { get; set; }
        public DateTime date { get; set; }
    }
}