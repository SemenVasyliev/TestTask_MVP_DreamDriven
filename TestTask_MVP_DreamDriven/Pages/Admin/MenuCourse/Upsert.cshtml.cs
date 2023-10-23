using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository;
using TestTask_MVP_DreamDriven.Models;
using TestTask_MVP_DreamDriven.Models.ViewModels;
using TestTask_MVP_DreamDriven.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace TestTask_MVP_DreamDriven.Pages.Admin.MenuCourse
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
                _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }



        [BindProperty]
        public MenuCourseVM MenuCourseObj { get; set; }


        public IActionResult OnGet(int? id)
        {
            MenuCourseObj = new MenuCourseVM
            {
                CategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                ComplexityList = _unitOfWork.Complexity.GetComplexityListForDropDown(),
                MenuCourse = new Models.MenuCourse()
            };
            
            if (id != null)
            {
                MenuCourseObj.MenuCourse = _unitOfWork.MenuCourse.GetFirstOfDefault(u => u.Id == id);
                if (MenuCourseObj.MenuCourse == null)
                {
                    return NotFound();
                }
            }
            return Page();

        }


        public IActionResult OnPost() 
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (MenuCourseObj.MenuCourse.Id == 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\menuCourse");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads,fileName+extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                MenuCourseObj.MenuCourse.Image = @"\images\menuCourse\" + fileName + extension;

                _unitOfWork.MenuCourse.Add(MenuCourseObj.MenuCourse);
            }
            else
            {
                // Edit Menu Course
                var objFromDb = _unitOfWork.MenuCourse.Get(MenuCourseObj.MenuCourse.Id);

                if (files.Count > 0) 
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\menuCourse");
                    var extension = Path.GetExtension(files[0].FileName);


                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }



                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    MenuCourseObj.MenuCourse.Image = @"\images\menuCourse\" + fileName + extension;

                }
                else
                {
                    MenuCourseObj.MenuCourse.Image = objFromDb.Image;
                }

                _unitOfWork.MenuCourse.Update(MenuCourseObj.MenuCourse);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}
