using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Data
{
    public class Location
    {
        public Guid OwnerID { get; set; }
        [Key]
        public int LocationID { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Display(Name = "Address")]
        public string Address
        {
            get
            {
                return (Street + " " + City + " " + State + " "+ ZipCode);
            }
        }
        [Required]
        public string HoursOfOperation { get; set; }
        [Required]
        public bool Open { get; set; }
        [Required]
        public bool Closed { get; set; }
        [Required]
        public bool Membership { get; set; }
        [Required]
        public bool Indoor { get; set; }
        [Required]
        public bool Outdoor { get; set; }
        public virtual ICollection<Player> ListOfPlayers { get; set; }
        public virtual ICollection<Team> ListOfTeams { get; set; }
        public virtual ICollection <Review> ListOfReviews { get; set; }
        public Location()
        {
            ListOfPlayers = new HashSet<Player>();
            ListOfTeams = new HashSet<Team>();
            ListOfReviews = new HashSet<Review>();
        }

        //foreach within your servie layer. 
        //Use one of the models list of players, team and reviews to return it the way you want the data structured. manipulate of 
    }
}
