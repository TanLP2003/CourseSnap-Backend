using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Contracts
{
    public interface ICourseRepo
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetByName(string name);
        Task Add(Course course);
        Task<bool> Update(Course course);
        Task<bool> Delete(string id);
    }
}
