using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.Review
{
   public class ReviewDetail
    {
        public int ReviewID { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public bool IsRecommended { get; set; }
        public int LocationRating { get; set; }
    }
}
