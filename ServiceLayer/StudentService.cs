using Domain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo studentRepo;
        public StudentService(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        public void AddStudents(Student student)
        {
            studentRepo.Add(student);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await studentRepo.GetAll<Student>();
        }
    }
}
