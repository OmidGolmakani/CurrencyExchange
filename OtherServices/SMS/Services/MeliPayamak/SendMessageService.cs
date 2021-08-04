using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.OtherServices.SMS.Dto.MeliPayamak;
using CurrencyExchange.OtherServices.Rest.Dto;
using System.Xml.Linq;
using CurrencyExchange.Helpers;

namespace CurrencyExchange.OtherServices.SMS.Services.MeliPayamak
{
    public class SendMessageService : Base.BaseSevice
    {
        private readonly IOptions<Dto.MeliPayamak.SmsConfig> _SmsConfig;
        private readonly RestClient _restClient;
        private readonly RestRequest _restRequest;

        public SendMessageService(IOptions<Dto.MeliPayamak.SmsConfig> SmsConfig,
                                  RestClient restClient,
                                  RestRequest restRequest)
        {
            _restClient = restClient;
            _restRequest = restRequest;
            _restClient.BaseUrl = new Uri(SmsConfig.Value.Urls.FirstOrDefault(x => x.Name == "SendMessage").Address);
            _SmsConfig = SmsConfig;
        }

        public string SendMessage(string Mobile, string Message)
        {
            //var RequestBody = string.Format("username={0}&password={1}&to={2}&from={3}&text={4}&isflash=false",
            //    _SmsConfig.Value.Authentication.UserName,
            //    _SmsConfig.Value.Authentication.Password,
            //    Mobile,
            //    _SmsConfig.Value.SmsNumbers.FirstOrDefault(),
            //    Message);
            //_restRequest.Method = Method.POST;
            //_restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
            //_restRequest.AddHeader("postman-token", _SmsConfig.Value.Authentication.Token);
            //_restRequest.AddHeader("cache-control", "no-cache");
            //_restRequest.AddParameter("application/x-www-form-urlencoded", RequestBody, ParameterType.RequestBody);
            //var Response = _restClient.Execute(_restRequest);
            //var Result = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<Messages>>(Response.Content);
            //return Result;

            var RequestBody = string.Format("username={0}&password={1}&text={2}&to={3}&bodyid={4}",
                _SmsConfig.Value.Authentication.UserName,
                _SmsConfig.Value.Authentication.Password,
                Message,
                Mobile,
                54402);
            _restRequest.Method = Method.POST;
            _restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
            //_restRequest.AddHeader("postman-token", _SmsConfig.Value.Authentication.Token);
            _restRequest.AddHeader("cache-control", "no-cache");
            _restRequest.AddParameter("application/x-www-form-urlencoded", RequestBody, ParameterType.RequestBody);
            var Response = _restClient.Execute(_restRequest);
            var xml = XDocument.Parse(Response.Content);
            long Result = ((System.Xml.Linq.XContainer)xml.FirstNode).FirstNode.ToString().ToLong();
            return GetSMSResult(Result);
        }
        private string GetSMSResult(long Value)
        {
            switch (Value)
            {
                case -7:
                    return "خطایی در شماره فرستنده رخ داده است با پشتیبانی تماس بگیرید.";
                case -6:
                    return "خطای داخلی رخ داده است با پشتیبانی تماس بگیرید.";
                case -5:
                    return "متن ارسالی با توجه به متغیر های مشخص شده در متن پیشفرض همخوانی ندارد";
                case -4:
                    return "کد متن ارسالی صحیح نمی باشد و یا توسط مدیر سامانه تایید نشده است.";
                case -3:
                    return "خط ارسالی در سیستم تعریف نشده است، با پشتیبانی سامانه تماس بگیرید.";
                case -2:
                    return "محدودیت تعداد شماره، محدودیت هر بار ارسال 1 شماره موبایل می باشد.";
                case -1:
                    return "دسترسی برای استفاده از این وبسرویس غیرفعال است، با پشتیبانی تماس بگیرید.";
                case 0:
                    return "نام کاربری یا رمز عبور صحیح نمی باشد.";
                case 2:
                    return "اعتبار کافی نمی باشد";
                case 6:
                    return "سامانه در حال بروزرسانی می باشد";
                case 7:
                    return "متن حاوی کلمه فیلتر شده می باشد.با واحد اداری تماس بگیرید";
                case 10:
                    return "کاربر مورد نظر فعال نمی باشد";
                case 11:
                    return "ارسال نشده";
                case 12:
                    return "مدارک کاربر کامل نمی باشد";
                default:
                    return Value.ToString();
            }
        }
    }
}
