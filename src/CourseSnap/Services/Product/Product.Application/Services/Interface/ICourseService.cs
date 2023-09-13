using Product.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Services.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseReturnModel>> GetAll();
        Task<CourseReturnModel> GetByName(string courseName);
        Task<CourseReturnModel> Add(CourseCreateModel courseCreateModel);
        Task Update(string name, CourseUpdateModel courseUpdateModel);
        Task Delete(string courseName);
    }
}
