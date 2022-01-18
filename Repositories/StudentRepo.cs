using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StudentRepo : IStudentRepo
    {
        public void Add<T>(T student) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetStudents()
        {
            throw new NotImplementedException();
        }
    }
}
