using Microsoft.EntityFrameworkCore;
using StudentManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Data.Interfaces
{
    public interface IStudentManagerContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public void SaveChanges();
    }
}
