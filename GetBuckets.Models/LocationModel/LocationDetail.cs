﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.LocationModel
{
    public class LocationDetail
    {
        public string LocationName { get; set; }
        public string Address
        {
            get
            {
                return (Street + " " + State + " " + City + " " + ZipCode);
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
        public bool OpenOrClosed { get; set; }
        [Required]
        public bool Memembership { get; set; }
        [Required]
        public bool Indoor { get; set; }
        [Required]
        public bool Outdoor { get; set; }

    }
}