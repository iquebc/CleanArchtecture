using AutoMapper;
using CleanArchtectureMVC.Application.DTOs;
using CleanArchtectureMVC.Application.Products.Commands;
using CleanArchtectureMVC.Domain.Model;

namespace CleanArchtectureMVC.Application.Mapping
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}