using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository;

namespace TestTask_MVP_DreamDriven.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;


        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository (_db);
            Complexity = new ComplexityRepository (_db);
            MenuCourse = new MenuCourseRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IComplexityRepository Complexity { get; private set; }
        public IMenuCourseRepository MenuCourse { get; private set; }
    }
}
