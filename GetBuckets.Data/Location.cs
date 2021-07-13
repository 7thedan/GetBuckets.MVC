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
        [Key]
        public int LocationID { get; set; }
        public string Address { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        [Display(Name = "Name of the Location")]
        public string LocationOfPlayer
        {
            get
            {
                return (Address + " " + City + " " + State);
            }
        }
        [Required]
        public bool OpenOrClosed { get; set; }
        [Required]
        public bool Membership { get; set; }
        [Required]
        public bool Indoor { get; set; }
        [Required]
        public bool Outdoor { get; set; }
        public ICollection<Player> ListOfPlayers { get; set; }
        public ICollection<Team> ListOfTeams { get; set; }
        public ICollection<Review> ListOfReviews { get; set; }
        public Location()
        {
            ListOfPlayers = new HashSet<Player>();
            ListOfTeams = new HashSet<Team>();
            ListOfReviews = new HashSet<Review>();
        }
       
    }
}
