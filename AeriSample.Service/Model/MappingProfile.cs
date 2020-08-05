using AeriSample.Data.Entity;
using AeriSample.Service.Model.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AeriSample.Service.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductCostHistory, ProductCostHistoryDTO>().ReverseMap();

        }
    }
}
