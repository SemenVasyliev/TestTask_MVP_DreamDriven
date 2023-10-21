using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository;

namespace TestTask_MVP_DreamDriven.DataAccess.Data.Repository
{
    internal class UnitOfWork : iUnitOfWork
    {
        private readonly ApplicationDbContext _db;


        public void Save()
        {
            throw new NotImplementedException();
        }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository (_db);
            }

        public ICategoryRepository Category { get; set; }
    }
}
