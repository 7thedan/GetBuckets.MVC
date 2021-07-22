using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.PlayerModel
{
    public class PlayerDetail
    {
        public int PlayerID { get; set; }
        [Required]
        [Display(Name = "Player's Email Address")]
        public string PlayerEmail { get; set; }
        [Display(Name = "Player's UserName")]
        public string UserName { get; set; }
        [Display(Name = "Player's Height")]
        public int Height { get; set; }
        [Display(Name = "Player's Skill Level")]
        public string Skill { get; set; }
        [Display(Name = "Player's Preferred Position")]
        public string Position { get; set; }
        [Display(Name = "Player's Location")]
        public string Location { get; set; }
        [Display(Name = "Player Preferred to Play Indoor")]
        public bool Indoor { get; set; }
        [Display(Name = "Player Preferred to Play Outdoor")]
        public bool Outdoor { get; set; }
        [Display(Name = "Player's Team")]
        public int? TeamID { get; set; }

    }
}
