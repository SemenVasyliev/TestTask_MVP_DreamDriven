using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository
{
    public interface iUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        void Save();
    }
}
