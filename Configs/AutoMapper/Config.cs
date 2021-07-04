﻿using AutoMapper;
using CurrencyExchange.Models.Dto.ApplicationUsers;
using CurrencyExchange.Models.Dto.Currencies;
using CurrencyExchange.Models.Dto.CurrencyChanges;
using CurrencyExchange.Models.Dto.Orders;
using CurrencyExchange.Models.Entity;

namespace CurrencyExchange.Configs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Identity Tables
            CreateMap<ApplicationUser, CUApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterWithPhoneDto>().ReverseMap();
            #endregion Identity Tables
            #region Currency Changes
            CreateMap<CurrencyChange, CurrencyChangeDto>().ReverseMap();
            CreateMap<CurrencyChange, CUCurrencyChangeDto>().ReverseMap();
            #endregion Currency Changes
            #region Currencies
            CreateMap<Currency, CurrencyDto>().ReverseMap();
            CreateMap<Currency, CUCurrencyDto>().ReverseMap();
            #endregion Currencies
            #region Orders
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CUOrderDto>().ReverseMap();
            #endregion Orders            
        }
    }
}
