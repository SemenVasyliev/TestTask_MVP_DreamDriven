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
    public class ComplexityRepository : Repository<Complexity>, IComplexityRepository
    {
        private readonly ApplicationDbContext _db;

        public ComplexityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetComplexityListForDropDown()
        {
            return _db.Complexity.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.ToString()
            });
        }
        public void Update(Complexity complexity)
        {
            var objFromDb = _db.Category.FirstOrDefault(s => s.Id == complexity.Id);

            objFromDb.Name = complexity.Name;
            objFromDb.DisplayCourses = complexity.DisplayCourses;

            _db.SaveChanges();
        }
    }
}
