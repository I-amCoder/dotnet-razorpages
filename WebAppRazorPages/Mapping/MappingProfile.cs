using AutoMapper;
using WebAppRazorPages.Models;
using WebAppRazorPages.Models.Dtos;

namespace WebAppRazorPages.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductUpdate>().ReverseMap();
            CreateMap<Product ,ProductCreate>().ReverseMap();
        }
    }
}
