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
        [Required]
        [Display(Name = "Rate the Location")]
        public int LocationRating { get; set; }
        [MaxLength(500, ErrorMessage = "There are too many characteres in this field")]
        public string Post { get; set; }
        public string Address { get; set; }
        [Display(Name = "Would you recommend this location to your friends?")]
        public bool IsRecommended { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
