using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository;

namespace TestTask_MVP_DreamDriven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Category.GetAll() });
        }
    }
}
