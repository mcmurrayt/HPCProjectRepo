using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyDoc.Shared
{
    public class FipsCounty
    {
        public string Id { get; set; }
        [Column(TypeName = "Char(2)")]
        public string CountyFIPSCode { get; set; }
        [Column(TypeName = "VarChar(150)")]
        public string CountyName { get; set; }
        public string FipsStateId { get; set; }

    }
}
