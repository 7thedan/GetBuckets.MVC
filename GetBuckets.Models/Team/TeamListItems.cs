using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.Team
{
    public class TeamListItems
    {
        public int TeamID { get; set; }
        [Required]
        public string TeamName { get; set; }
        public string LocationName { get; set; }
        public int PlayerID { get; set; }

    }
}
