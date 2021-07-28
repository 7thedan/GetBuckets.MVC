using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.LocationModel
{
    public class LocationDetail
    {

        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Address
        {
            get
            {
                return (Street + " " + City + " " + State + " " + ZipCode);
            }
        }
        [Required]
        public string Street { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        [Display(Name = "Is the facility still Open")]
        public bool Open { get; set; }
        [Required]
        [Display(Name = "Is the facility still operational?")]
        public bool Closed { get; set; }
        [Required]
        public string HoursOfOperation { get; set; }
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
