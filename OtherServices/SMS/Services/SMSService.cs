using CurrencyExchange.OtherServices.Base;
using CurrencyExchange.OtherServices.SMS.Dto;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.OtherServices.SMS.Services
{
    public class SMSService : BaseSevice
    {
        private readonly IOptions<SMSConfig> _SMSConfig;

        public SMSService(IOptions<SMSConfig> SMSConfig)
        {
            _SMSConfig = SMSConfig;
        }
        internal Task<IRestResponse> SendSMSWithPattern(string smsData,string PhoneNumber,Enum.Pattern.type patternType)
        {
            SendWithPattern smsDataPatern = new SendWithPattern();
            string Url = string.Format("{0}{1}", _SMSConfig.Value.Url, _SMSConfig.Value.APIKey);
            var client = new RestClient(Url);
            smsDataPatern.user = _SMSConfig.Value.UserName;
            smsDataPatern.pass = _SMSConfig.Value.Password;
            smsDataPatern.op = "patternV2";
            smsDataPatern.patternCode = _SMSConfig.Value.Patterns.FirstOrDefault(x => x.Name == patternType.ToString()).Value;
            smsDataPatern.fromNum = _SMSConfig.Value.SMSNumbers.FirstOrDefault();
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", Newtonsoft.Json.JsonConvert.SerializeObject(smsDataPatern), ParameterType.RequestBody);
            //request.AddParameter("undefined", "{\"op\" : \"patternV2\"" +
            //    ",\"user\" : \"yourUsername\"" +
            //    ",\"pass\":  \"yourPassword\"" +
            //    ",\"fromNum\" : \"100009\"" +
            //    ",\"toNum\": \"09100980098\"" +
            //    ",\"patternCode\": \"545\"" +
            //    ",\"inputData\" : {\"smstext\": \"asdadas\"}}"
            //, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return Task.FromResult(response);
        }
    }
}
