using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerCheck.Models
{
    public class Owner
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        public DateTime CreationDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Registration> Registrations { get; set; }
    }
}
