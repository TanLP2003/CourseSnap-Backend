using MongoDB.Driver;
using Product.Application.Services.Interface;
using Product.Domain.Entities;
using Product.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Product.Application.Models;
using Product.Domain.Exceptions;
using System.Globalization;

namespace Product.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepo _repo;
        private readonly ILogger<CourseService> _logger;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepo repo, ILogger<CourseService> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseReturnModel>> GetAll()
        {
            var courses = await _repo.GetAll(); 
            return _mapper.Map<IEnumerable<CourseReturnModel>>(courses);
        }

        public async Task<CourseReturnModel> GetByName(string name)
        {
            var course = await _repo.GetByName(name);
            return _mapper.Map<CourseReturnModel>(course);
        }

        public async Task<CourseReturnModel> Add(CourseCreateModel courseCreateModel)
        {
            var course = await _repo.GetByName(courseCreateModel.Name);
            if (course != null)
            {
                throw new BadRequestException($"Course with name {courseCreateModel.Name} already existed");
            }

            var newCourse = _mapper.Map<Course>(courseCreateModel);
            await _repo.Add(newCourse);
            return _mapper.Map<CourseReturnModel>(newCourse);
        }

        public async Task Update(string name, CourseUpdateModel model)
        {
            var course = await _repo.GetByName(name);
            if(course == null)
            {
                throw new NotFoundException($"Course with name: {name} doesn't exist");
            }

            _mapper.Map(model, course);

            var result = await _repo.Update(course); 
            if (!result)
            {
                _logger.LogError("Update Fail!!!");
                throw new BadRequestException($"Update Fail");
            }
            _logger.LogInformation("Update Success!!!");
        }

        public async Task Delete(string courseName)
        {
            var course = await _repo.GetByName(courseName);
            if(course == null)
            {
                throw new NotFoundException($"Course with name: {courseName} doesn't exist");
            }

            var result = await _repo.Delete(course.Id);
            if (!result)
            {
                _logger.LogError("Delete Fail!!!");
                throw new BadRequestException("Delete Fail");
            }
            _logger.LogInformation("Delete Success!!!");
        }
    }
}
