using Microsoft.AspNetCore.Mvc;
using TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository;

namespace TestTask_MVP_DreamDriven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuCourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MenuCourseController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.MenuCourse.GetAll(null,null,"Category,Complexity") });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var ObjFromDb = _unitOfWork.MenuCourse.GetFirstOfDefault(u => u.Id == id);
                if (ObjFromDb == null)
                {
                    return Json(new { success = false, message = "Error while deleting" });
                }

                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, ObjFromDb.Image.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                _unitOfWork.MenuCourse.Remove(ObjFromDb);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error while deleting"}); 
            }

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
