using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IStudentService
    {
        void AddStudents<T>(T student) where T : class;
        Task<IEnumerable<Student>> GetStudents();
    }
}
