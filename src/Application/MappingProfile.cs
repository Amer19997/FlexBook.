using AutoMapper;
using FlexBook.Application.Common.Models;
using FlexBook.Domain.Entities.Catalog.Dtos;
using FlexBook.Domain.Entities.Catalog;
using FlexBook.Domain.Entities.LookUps;
using X.PagedList;
using FlexBook.Application.Common.Mappings;

namespace FlexBook.Application;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
         
        CreateMap<Course, CourseDetailDTO>();
        CreateMap<Section,SectionDto>();
        // Mapping between individual Course and CourseDto
        CreateMap<Course, CourseDto>();
        CreateMap<Lesson, LessonDto>(); 

        // Mapping for IPagedList<Course> to IPagedList<CourseDto>
        CreateMap<IPagedList<Course>, IPagedList<CourseDto>>()
            .ConvertUsing<PagedListConverter<Course, CourseDto>>();

        // Mapping Topic -> TopicDto
        CreateMap<Topic, TopicDto>()
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));

        // Mapping Category -> CategoryNameDto (Only Name fields)
        CreateMap<Category, CategoryNameDto>();

    }
   
}
