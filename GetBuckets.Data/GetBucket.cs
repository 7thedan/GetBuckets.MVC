using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBuckets.Data
{
    public class GetBucket
    {
        [Key]
        public string PlayerId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        [Display(Name = "What is your Skill/Experience Level?")]
        public string Skill { get; set; }
        public bool Indoor { get; set; }
        public bool Outdoor { get; set; }
        public int TeamID { get; set; }
        public string Location { get; set; }

    }
}
