﻿using System;
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
        public string TeamName { get; set; }

        [ForeignKey(nameof(Location))]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
        public ICollection<Player> ListOfPlayers { get; set; }
        public Team()
        {
            ListOfPlayers = new HashSet<Player>();
        }

    }
}