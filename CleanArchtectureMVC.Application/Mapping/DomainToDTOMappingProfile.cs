using AutoMapper;
using CleanArchtectureMVC.Application.DTOs;
using CleanArchtectureMVC.Domain.Model;

namespace CleanArchtectureMVC.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}