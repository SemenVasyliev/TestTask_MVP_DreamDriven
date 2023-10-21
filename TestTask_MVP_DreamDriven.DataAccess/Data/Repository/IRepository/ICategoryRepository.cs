using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestTask_MVP_DreamDriven.Models;

namespace TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategryListForDropDown();

        void Update(Category category);
    }
}
