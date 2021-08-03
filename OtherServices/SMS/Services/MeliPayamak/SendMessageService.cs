using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.OtherServices.SMS.Dto.MeliPayamak;
using CurrencyExchange.OtherServices.Rest.Dto;

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

        public ApiResult<string> SendMessage(string Mobile, string Message)
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
            return null;
            //var Result = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<Messages>>(Response.Content);
            //return Result;
        }

    }
}
