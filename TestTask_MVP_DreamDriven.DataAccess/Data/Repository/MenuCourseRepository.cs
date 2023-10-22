using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository;
using TestTask_MVP_DreamDriven.Models;

namespace TestTask_MVP_DreamDriven.DataAccess.Data.Repository
{
    public class MenuCourseRepository : Repository<MenuCourse>, IMenuCourseRepository
    {
        private readonly ApplicationDbContext _db;

        public MenuCourseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MenuCourse menuCourse)
        {
           var menuCourseFromDb = _db.MenuCourse.FirstOrDefault(m=>m.Id == menuCourse.Id);

            menuCourseFromDb.Name = menuCourse.Name;
            menuCourseFromDb.CategoryId = menuCourse.CategoryId;
            menuCourseFromDb.Description = menuCourse.Description;
            menuCourseFromDb.ComplexityId = menuCourse.ComplexityId;
            menuCourseFromDb.AmountOfLessons = menuCourse.AmountOfLessons;
            if (menuCourse.Image!=null)
            {
                menuCourseFromDb.Image = menuCourse.Image;
            }
            _db.SaveChanges();
            
        }
    }
}
