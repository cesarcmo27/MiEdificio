using Application.Categories;
using Application.Groups;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Group,Group>();
            CreateMap<Group,GroupDTO>();
            
            CreateMap<Category, CategoryDTO>();
            
        }
    }
}