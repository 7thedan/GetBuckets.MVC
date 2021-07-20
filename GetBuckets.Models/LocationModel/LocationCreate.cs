using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.LocationModel
{
    public class LocationCreate
    {
        public int LocationID { get; set; }
        [Required]
        [MinLength(0, ErrorMessage = "Please enter character")]
        [MaxLength(30, ErrorMessage = "There are too many charcters in this field")]
        public string LocationName { get; set; }
        public string Address { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        [Display(Name = "Open or Closed")]
        public bool OpenOrClosed { get; set; }
        [Required]
        [Display(Name = "Does it require membership?")]
        public bool Memembership { get; set; }
        [Required]
        [Display(Name = "Indoor friendly?")]
        public bool Indoor { get; set; }
        [Required]
        [Display(Name = "Outdoor friendly?")]
        public bool Outdoor { get; set; }

    }
}
