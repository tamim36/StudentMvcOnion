using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IStudentRepo
    {
        void Add<T>(T student) where T : class;
        Task<IEnumerable<T>> GetAll<T>();
    }
}
