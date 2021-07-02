using AutoMapper;
using CurrencyExchange.Models.Dto.ApplicationUsers;
using CurrencyExchange.Models.Dto.CurrencyChanges;
using CurrencyExchange.Models.Entity;
using NetTopologySuite.Geometries;

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
            CreateMap<CurrencyChange, CurrencyChangeDto>().ReverseMap();
           
            #endregion Identity Tables
        }
    }
}
