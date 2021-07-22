using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.PlayerModel
{
    public class PlayerEdit
    {
        [Required]
        [Display(Name = "Player's ID")]
        public int PlayerID { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Player's Email")]
        public string PlayerEmail { get; set; }
        [Required]
        [Display(Name = "Player's height ")]
        public int Height { get; set; }
        [Required]
        [Display(Name = "Player's experienced level in basketball")]
        public string Skill { get; set; }
        [Required]
        [Display(Name = "Player's Position")]
        public string Position { get; set; }
        [Required]
        [Display(Name = "Player's Location")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Player Prefer Indoor")]
        public bool Indoor { get; set; }
        [Required]
        [Display(Name = "Player Prefer Outdoor?")]
        public bool Outdoor { get; set; }
    }
}
