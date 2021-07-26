using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.Review
{
   public class ReviewListItems
    {   
        public int ReviewID { get; set; }
        public int PlayerID { get; set; }
        public int LocationID { get; set; }
        [Required]
        public string Address { get; set; }
        [Display(Name = "Leave your experience of the court")]
        public string Comment { get; set; }
        [Required]
        [Display(Name = "Would you recommend this court to your friends?")]
        public bool IsRecommended { get; set; }
        [Required]
        [Display(Name = "What rating would you give of the court?")]
        public int LocationRating { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }
    }
}
