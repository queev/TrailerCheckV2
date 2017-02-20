using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailerCheck.Models
{
    public class Trailer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrailerID { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
