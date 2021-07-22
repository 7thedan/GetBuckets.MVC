using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Models.PlayerModel
{
    public class PlayerCreate
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string PlayerEmail { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required] 
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Enter your height in cm")]
        public int Height { get; set; }
        [Required]
        [Display(Name = "Enter your experienced level in basketball")]
        public string Skill { get; set; }
        [Required]
        [Display(Name = "What is your the position you play?")]
        public string Position { get; set; }
        [Required]
        [Display(Name = "Where is your current location?")]
        public string Location { get; set; }
        [Required]
        [Display(Name ="Do you prefer Indoor?")]
        public bool Indoor { get; set; }
        [Required]
        [Display(Name ="Do you prefer Outdoor?")]
        public bool Outdoor { get; set; }

    }
}
