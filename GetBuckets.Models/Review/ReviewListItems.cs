using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.Review
{
    public class ReviewListItems
    {
        public int ReviewID { get; set; }
        public string UserName { get; set; }
        public string LocationName { get; set; }
        public string Comment { get; set; }
        public bool IsRecommended { get; set; }
        public int LocationRating { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }

    }
}
