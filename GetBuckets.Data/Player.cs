using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Data //only delete migration if you made changes in the data layer. 
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="LastName")]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return (FirstName + "" + LastName);
            }
        }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string PlayerEmail { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public string Skill { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public bool Indoor { get; set; }
        [Required]
        public bool Outdoor { get; set; }
        [ForeignKey(nameof(Team))]
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
