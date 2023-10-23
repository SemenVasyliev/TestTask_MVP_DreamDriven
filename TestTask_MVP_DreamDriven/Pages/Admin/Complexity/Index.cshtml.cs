using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask_MVP_DreamDriven.Utility;

namespace TestTask_MVP_DreamDriven.Pages.Admin.Complexity
{
    [Authorize(Roles = SD.ManagerRole)]
    public class IndexModel : PageModel
    {
        
        public void OnGet()
        {
        }
    }
}
