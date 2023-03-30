using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindMyDoc.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public string firstName { get; set; }
        public string lastName { get; set; }
        //public date dob { get; set; }
        [Column(TypeName = "Date")] 
        public DateTime dob { get; set; }
        public string address { get; set; }
        public string insuranceNum { get; set; }
        public string? fips { get; set; }
        public string gender { get; set; }
        public DateTime date { get; set; }
        public string state { get; set; }
        public string county { get; set; }
    }
}