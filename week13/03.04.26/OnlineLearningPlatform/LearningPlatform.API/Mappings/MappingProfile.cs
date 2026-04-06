using AutoMapper;
using LearningPlatform.API.DTOs;
using LearningPlatform.API.Models;

namespace LearningPlatform.API.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            // Course mappings
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.InstructorName,
                    opt => opt.MapFrom(src => src.Instructor.Username))
                .ForMember(dest => dest.InstructorId,
                    opt => opt.MapFrom(src => src.InstructorId));
            CreateMap<CreateCourseDto, Course>();
            CreateMap<UpdateCourseDto, Course>();

            // Lesson mappings
            CreateMap<Lesson, LessonDto>();
            CreateMap<CreateLessonDto, Lesson>();

            // User mappings
            CreateMap<Models.User, UserDto>();
        }
    }
}