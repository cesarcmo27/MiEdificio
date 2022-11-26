using Application.Apartment;
using Application.Categories;
using Application.Excel;
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
            CreateMap<Domain.Apartment, ApartmentDTO>();
            CreateMap< ApartmentDTO,Domain.Apartment>();

            CreateMap<DataApartmentResult,Domain.Apartment>();
            
        }
    }
}