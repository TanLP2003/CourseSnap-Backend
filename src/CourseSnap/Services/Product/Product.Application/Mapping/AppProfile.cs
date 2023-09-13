using AutoMapper;
using Product.Application.Models;
using Product.Domain.Entities;

namespace Product.Application.Mapping
{
    public class AppProfile : Profile
    {
        public AppProfile() 
        {
            CreateMap<Course, CourseReturnModel>();
            CreateMap<CourseCreateModel, Course>()
                .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(des => des.LastUpdated, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<CourseUpdateModel, Course>()
                .ForMember(des => des.LastUpdated, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
