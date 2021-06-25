using AutoMapper;
using CurrencyExchange.Models.Dto.ApplicationUsers;
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
            //CreateMap<ApplicationUser, ApplicationUserSimpleDto>().ReverseMap();
            //CreateMap<ApplicationRole, ApplicationRoleDto>().ReverseMap();
            //CreateMap<ApplicationUserLogin, ApplicationUserLoginDto>().ReverseMap();
            //CreateMap<ApplicationRoleClaim, ApplicationRoleClaimDto>().ReverseMap();
            //CreateMap<ApplicationUserClaim, ApplicationUserClaimDto>().ReverseMap();
            //CreateMap<ApplicationUserToken, ApplicationUserTokenDto>().ReverseMap();
            #endregion Identity Tables
        }
    }
}
