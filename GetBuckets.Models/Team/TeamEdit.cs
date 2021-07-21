using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.Team
{
   public class TeamEdit
    {
        [Required]
        public string TeamName { get; set; }
       //bring foreignKey for locaiton?
    }
}
