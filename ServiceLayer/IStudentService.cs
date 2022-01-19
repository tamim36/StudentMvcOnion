using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IStudentService
    {
        void AddStudents(Student student);
        Task<IEnumerable<Student>> GetStudents();
    }
}
