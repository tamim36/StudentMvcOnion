using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StudentRepo : IStudentRepo
    {
        private readonly DataContext context;
        public StudentRepo(DataContext context)
        {
            this.context = context;
        }

        public void Add<T>(T student) where T : class
        {
            context.Add(student);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await context.Students.ToListAsync();
        }
    }
}
