using Microsoft.AspNetCore.Identity;

namespace FindMyDoc.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dob { get; set; }
        public string address { get; set; }
        public string insuranceNum { get; set; }
        public string fips { get; set; }
        public string gender { get; set; }
        public DateTime date { get; set; }
    }
}