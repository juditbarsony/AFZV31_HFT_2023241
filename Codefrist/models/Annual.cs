﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codefrist.models
{
    internal class Annual
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(100)]
        public string AnnualID { get; set; }
        [Required]
        [StringLength(300)]
        public string AnnualName { get; set; }

        public int pcs_m2 {get; set;}
    }
}
