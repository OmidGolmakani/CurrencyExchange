using AutoMapper;
using CurrencyExchange.Models.Dto.ApplicationUsers;
using CurrencyExchange.Models.Dto.AuthItems;
using CurrencyExchange.Models.Dto.AuthUserItems;
using CurrencyExchange.Models.Dto.BankAccounts;
using CurrencyExchange.Models.Dto.Currencies;
using CurrencyExchange.Models.Dto.CurrencyChanges;
using CurrencyExchange.Models.Dto.Images;
using CurrencyExchange.Models.Dto.Orders;
using CurrencyExchange.Models.Dto.Trades;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Helper;

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
            CreateMap<CurrencyChange, CUCurrencyChangeDto>().ReverseMap();
            CreateMap<CurrencyChangeDto, CurrencyChange>();
            CreateMap<CurrencyChange, CurrencyChangeDto>()
                .ForMember(dest => dest.CurrencyName, opts =>
                {
                    opts.MapFrom(src => Models.Helper.Currency.GetCurrncyName(src.Currency.CurrencyTypeId));
                });
            CreateMap<CurrencyChange, Models.Dto.CurrencyExchangeHub.CurrencyChangeDto>()
                .ForMember(dest => dest.CurrencyName, opts =>
                {
                    opts.MapFrom(src => Models.Helper.Currency.GetCurrncyName(src.Currency.CurrencyTypeId));
                });
            CreateMap<Models.Dto.CurrencyExchangeHub.CurrencyChangeDto, CurrencyChange>();
            #endregion Currency Changes
            #region Currencies
            CreateMap<Currency, CurrencyDto>().ReverseMap();
            CreateMap<Currency, CUCurrencyDto>().ReverseMap();
            #endregion Currencies
            #region Orders
            CreateMap<Order, OrderDto>().
                ForMember(dest => dest.UserFullName, opts =>
                {
                    opts.MapFrom(src => Models.Helper.ApplicationUser.GetUserFullName(src.OrderUser.Name, src.OrderUser.Family));
                }).ForMember(dest => dest.CurrencyName, opts =>
                {
                    opts.MapFrom(src => Models.Helper.Currency.GetCurrncyName(src.Currency.CurrencyTypeId));
                });
            CreateMap<OrderDto, Order>();
            CreateMap<Order, CUOrderDto>().ReverseMap();
            #endregion Orders            
            #region Trades
            CreateMap<Trades, TradeDto>().
                ForMember(dest => dest.UserFullName, opts =>
            {
                opts.MapFrom(src => src.Order.OrderUser.GetUserFullName());
            }).ForMember(dest => dest.CurrencyName, opts =>
            {
                opts.MapFrom(src => Models.Helper.Currency.GetCurrncyName(src.Order.Currency.CurrencyTypeId));
            });
            CreateMap<TradeDto, Trades>();
            CreateMap<Trades, CUTradeDto>().ReverseMap();
            #endregion Trades
            #region Bank Account
            CreateMap<BankAccount, BankAccountDto>().ReverseMap();
            CreateMap<BankAccount, CUBankAccountDto>().ReverseMap();
            #endregion Bank Account
            #region Image
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<Image, CUImageDto>().ReverseMap();
            #endregion Image
            #region AuthUserItem
            CreateMap<AuthUserItem, AuthUserItemDto>().ForMember(dest => dest.UserFullName, opts =>
            {
                opts.MapFrom(src => src.AuthUser.GetUserFullName());
                CreateMap<Image, CUImageDto>().ReverseMap();
                #endregion AuthUserItem
            });
        }
    }
}
