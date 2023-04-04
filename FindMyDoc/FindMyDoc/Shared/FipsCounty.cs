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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "Char(5)")]
        public string CountyFIPSCode { get; set; }
        [Column(TypeName = "VarChar(150)")]
        public string CountyName { get; set; }
        [ForeignKey("Id")]
        public int FipsStateId { get; set; }

        public virtual FipsState? FipsState { get; set; }
        

    }
}
