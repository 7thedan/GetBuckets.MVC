using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Data
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }

        [ForeignKey(nameof(Location))]
        public int LocationID { get; set; } 
        public virtual Location Location { get; set; }
        public int LocationRating { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public bool IsRecommended { get; set; }
        [Display(Name ="Review Date")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
