using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace FindMyDoc.Shared
{
    public class UserAuthDto
    {
        public string userName { get; set; }
        public string firstName { get; set; }
        public string Id { get; set; } = String.Empty; 
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

        public List<String>Roles { get; set; } = new();

    }
}
