using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.LocationModel
{
    public class LocationListItems
    {
        public string LocationName { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public bool OpenOrClosed { get; set; }
        public bool Membership { get; set; }
        public bool Indoor { get; set; }
        public bool Outdoor { get; set; }
    }
}
