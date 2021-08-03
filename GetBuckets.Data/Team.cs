using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Data
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        public string TeamName { get; set; }

        [ForeignKey(nameof(Location))]
        public int? LocationID { get; set; } //if you dont know the location make it nullable. For the sake of knowing. 
        public virtual Location Location { get; set; }
        public virtual ICollection<Player> ListOfPlayers { get; set; }
        public Team()
        {
            ListOfPlayers = new HashSet<Player>();
        }

    }
}
