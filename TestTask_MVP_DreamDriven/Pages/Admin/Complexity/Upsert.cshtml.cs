using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository;

namespace TestTask_MVP_DreamDriven.Pages.Admin.Complexity
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.Complexity ComplexityObj { get; set; }

        public IActionResult OnGet(int? id)
        {

            ComplexityObj = new Models.Complexity();
            if (id != null)
            {
                ComplexityObj = _unitOfWork.Complexity.GetFirstOfDefault(u => u.Id == id);
                if (ComplexityObj == null)
                {
                    return NotFound();
                }
            }
            return Page();

        }


        public IActionResult OnPost(Models.Complexity ComplexityObj)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ComplexityObj.Id == 0)
            {
                _unitOfWork.Complexity.Add(ComplexityObj);
            }
            else
            {
                _unitOfWork.Complexity.Update(ComplexityObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }

}
