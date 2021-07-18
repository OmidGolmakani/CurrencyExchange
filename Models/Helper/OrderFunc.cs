using CurrencyExchange.Models.Dto.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Helper
{
    internal static class OrderFunc
    {
        internal static string GetOrderStatus(Enum.Order.Status status)
        {
            switch (status)
            {
                case Enum.Order.Status.AwaitingConfirmation:
                    return "در انتظار تایید";
                case Enum.Order.Status.Confirmation:
                    return "تایید شده";
                case Enum.Order.Status.Reject:
                    return "رد شده";
                default:
                    return "";
            }
        }
        internal static string GetOrderStatus(byte status)
        {
            Enum.Order.Status statusType = (Enum.Order.Status)status;
            return GetOrderStatus(statusType);
        }
        internal static string GetOrderType(Enum.Order.OrderType orderType)
        {
            switch (orderType)
            {
                case Enum.Order.OrderType.None:
                    return "همه";
                case Enum.Order.OrderType.Buy:
                    return "خرید";
                case Enum.Order.OrderType.Sales:
                    return "فروش";
                default:
                    return "";
            }
        }
        internal static string GetOrderType(byte type)
        {
            Enum.Order.OrderType orderType = (Enum.Order.OrderType)type;
            return GetOrderType(orderType);
        }
        internal static string GetOrderType(this OrderDto x)
        {
            return GetOrderType(x.OrderTypeId);
        }
        internal static string GetOrderStatus(this OrderDto x)
        {
            return GetOrderStatus(x.Status);
        }
    }
}
