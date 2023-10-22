﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_MVP_DreamDriven.Models;

namespace TestTask_MVP_DreamDriven.DataAccess.Data.Repository.IRepository
{
    public interface IMenuCourseRepository : IRepository<MenuCourse>
    {
        void Update(MenuCourse menuCourse);
    }
}
