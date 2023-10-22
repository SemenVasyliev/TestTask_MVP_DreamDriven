using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_MVP_DreamDriven.Models
{
    public class MenuCourse
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount of lessons should be greater than 1")]
        public int AmountOfLessons { get; set; }


        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Display(Name = "Complexity Type")]
        public int ComplexityId { get; set; }

        [ForeignKey("ComplexityId")]
        public virtual Complexity Complexity { get; set; }


    }
}
