﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyDoc.Shared
{
    public class FipsState
    {
        public string Id { get; set; }
        [Column(TypeName = "Char(2)")]
        public string StateFIPSCode { get; set; }
        [Column(TypeName = "VarChar(150)")]
        public string StateName { get; set; }
        public virtual FipsCounty County { get; set; }
    }
}
