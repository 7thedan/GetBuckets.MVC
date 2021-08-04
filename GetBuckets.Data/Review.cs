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
        [Required]
        public Guid OwnerID { get; set; }
        [Key]
        public int ReviewID { get; set; }
        [ForeignKey(nameof(Player))]
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
        [ForeignKey(nameof(Location))]
        public int LocationID { get; set; } 
        public virtual Location Location { get; set; }
        public int LocationRating { get; set; }
        //public string Address { get; set; }
        public string Comment { get; set; } //string is nullable. 
        public bool IsRecommended { get; set; }
        [Required]
        [Display(Name = "Created On")]
        public DateTimeOffset DateCreated { get; set; }
        [Display(Name ="Modified On")]
        public DateTimeOffset? DateModified { get; set; }

    }
}
