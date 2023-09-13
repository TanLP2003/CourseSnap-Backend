using MongoDB.Driver;
using Product.Domain.Contracts;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repositories
{
    public class CourseRepo : ICourseRepo
    {
        private readonly ICourseContext _context;

        public CourseRepo(ICourseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses.Find(c => true).ToListAsync();
        }

        public async Task<Course> GetByName(string name)
        {
            var filter = Builders<Course>.Filter.Eq(c => c.Name, name);
            return await _context.Courses.Find(filter).FirstOrDefaultAsync();   
        }

        public async Task Add(Course course)
        {
            await _context.Courses.InsertOneAsync(course);
        }

        public async Task<bool> Update(Course course)
        {
            var filter = Builders<Course>.Filter.Eq(c => c.Name, course.Name);
            
            var result = await _context.Courses.ReplaceOneAsync(filter, course);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _context.Courses.DeleteOneAsync(c => c.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}
