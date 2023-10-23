using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository;
using TestTask_MVP_DreamDriven.Models;

namespace TestTask_MVP_DreamDriven.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
            private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MenuCourse> MenuCourseList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }

        public void OnGet()
        {

            /*var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                int shoppingCartCount = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(SD.ShoppingCart, shoppingCartCount);
            }*/

            MenuCourseList = _unitOfWork.MenuCourse.GetAll(null, null, "Category,Complexity");
            CategoryList = _unitOfWork.Category.GetAll(null, q => q.OrderBy(c => c.DisplayCourses), null);
        }
    }
}
