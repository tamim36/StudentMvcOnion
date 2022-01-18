using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class StudentService : IStudentService
    {
        public void AddStudents<T>(T student) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            throw new NotImplementedException();
        }
    }
}
