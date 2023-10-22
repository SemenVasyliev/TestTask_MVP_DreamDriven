using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_MVP_DreamDriven.Models
{
    public class Complexity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Complexity Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Display Courses")]
        public int DisplayCourses { get; set; }

    }
}
