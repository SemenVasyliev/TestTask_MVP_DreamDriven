using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestTask_MVP_DreamDriven.Models.ViewModels
{
    public  class MenuCourseVM
    {
        public MenuCourse MenuCourse { get; set; }
        public IEnumerable <SelectListItem> CategoryList { get; set; }

        public IEnumerable<SelectListItem> ComplexityList { get; set; }
    }
}
