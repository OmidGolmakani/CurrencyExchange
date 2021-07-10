using AutoMapper;
using CurrencyExchange.Models.Dto.ApplicationUsers;
using CurrencyExchange.Models.Dto.BankAccounts;
using CurrencyExchange.Models.Dto.Currencies;
using CurrencyExchange.Models.Dto.CurrencyChanges;
using CurrencyExchange.Models.Dto.Images;
using CurrencyExchange.Models.Dto.Orders;
using CurrencyExchange.Models.Dto.Trades;
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
            CreateMap<Order, OrderDto>().
                ForMember(dest => dest.UserFullName, opts =>
                {
                    opts.MapFrom(src => string.Format("{0} {1}", src.OrderUser.Name, src.OrderUser.Family));
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
                opts.MapFrom(src => string.Format("{0} {1}", src.Order.OrderUser.Name, src.Order.OrderUser.Family));
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
        }
    }
}
