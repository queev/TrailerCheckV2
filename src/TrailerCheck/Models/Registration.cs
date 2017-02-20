using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerCheck.Models
{
    public class Registration
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
        public int TrailerID { get; set; }

        public Owner Owner { get; set; }
        public Trailer Trailer { get; set; }
    }
}
