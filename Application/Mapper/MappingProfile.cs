using AutoMapper;
using Domain;
using StoreWebAPI.Application.Category;

namespace Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<NewCategoryRequest, Category>();
        CreateMap<Category, NewCategoryResponse>();


    }




}
