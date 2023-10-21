using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository;
using TestTask_MVP_DreamDriven.Models;

namespace TestTask_MVP_DreamDriven.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategryListForDropDown()
        {
            return _db.Category.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.ToString()
            });
        }
        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(s => s.Id == category.Id);

            objFromDb.Name = category.Name;
            objFromDb.DisplayCourses = category.DisplayCourses;

            _db.SaveChanges();
        }
    }
}
