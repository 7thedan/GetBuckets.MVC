using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.Review
{
    public class ReviewCreate
    {
        public int PlayerID { get; set; }
        public int LocationID { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public bool IsRecommended { get; set; }
        [Required]
        public int LocationRating { get; set; }
    }
}
