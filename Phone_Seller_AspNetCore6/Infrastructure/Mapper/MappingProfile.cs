using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System.Configuration;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BrandDto, Brand>();
            CreateMap<PhoneDto, Phone>();
            CreateMap<OrderDto, Order>();
            CreateMap<BrandDto, Brand>().ReverseMap();
            CreateMap<PhoneDto, Phone>().ReverseMap();
            CreateMap<Phone, PhoneDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto,OrderDtoForCreation>().ReverseMap();
            CreateMap<OrderDto, OrderDtoForCreation>();
            CreateMap<PhoneDtoForCreation, Phone>();
            CreateMap<PhoneDtoForUpdate, Phone>().ReverseMap();
            CreateMap<BrandDtoForCreation, Brand>();
            CreateMap<BrandDtoForUpdate, Brand>().ReverseMap();
            CreateMap<UserDtoForCreation, CustomUser>();
            CreateMap<UserDtoForUpdate, CustomUser>().ReverseMap();
            CreateMap<OrderDtoForCreation, Order>();
            CreateMap<OrderDtoForUpdate, Order>().ReverseMap();

        }
    }
}