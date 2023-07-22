using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeaHouse.Models;

namespace TeaHouse.Core.mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Categories
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryFormViewModel, Category>().ReverseMap();
            //Products
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductFormViewModel, Product>().ReverseMap();
        }
    }
}