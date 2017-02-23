﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrailerCheck.Models
{
    public class Trailer
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Serial Number")]
        [RegularExpression(@"^[0-9]+$")]
        [StringLength(7, MinimumLength = 4)]
        public int TrailerID { get; set; }

        [Required]
        [Display(Name = "Product Group")]
        public string ProductGroup { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
