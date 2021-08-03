//using Microsoft.Extensions.Options;
//using Newtonsoft.Json;
//using RestSharp;
//using Selle.WebApp.Data;
//using Selle.WebApp.Helper;
//using Selle.WebApp.Model.Dto.ApiResults;
//using Selle.WebApp.Services.External.SMS.Dto;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CurrencyExchange.OtherServices.SMS.Services.MeliPayamak
//{
//    public class GetMessagesService : BaseRestService<Dto.SmsConfig>
//    {
//        private readonly ApplicationDbContext _dbContext;
//        private readonly IOptions<SmsConfig> _smsConfig;
//        private readonly TextSendBoxesService _TextMessageService;
//        public GetMessagesService(IOptions<Dto.SmsConfig> SmsConfig,
//                                  RestClient restClient,
//                                  RestRequest restRequest,
//                                  TextSendBoxesService TextMessageService,
//                                  ApplicationDbContext dbContext)
//           : base(restClient, restRequest)
//        {
//            this._dbContext = dbContext;
//            _smsConfig = SmsConfig;
//            this._TextMessageService = TextMessageService;
//        }
//        public Task<List<Dto.Messages>> GetMessages(Enum.Message.Type MessageType = Enum.Message.Type.Posted)
//        {
//            try
//            {
//                _restClient.BaseUrl = new Uri(_smsConfig.Value.Urls.FirstOrDefault(x => x.Name == "GetMessages").Address);
//                var RequestBody = string.Format("username={0}&password={1}&location={2}&from={3}&index=0&count=100",
//                    _smsConfig.Value.Authentication.UserName,
//                    _smsConfig.Value.Authentication.Password,
//                    (int)MessageType,
//                    _smsConfig.Value.SmsNumbers.FirstOrDefault());
//                _restRequest.Method = Method.POST;
//                _restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
//                _restRequest.AddHeader("postman-token", "aff8511f-0fef-6461-711c-beab61fc0fb1");
//                _restRequest.AddHeader("cache-control", "no-cache");
//                _restRequest.AddParameter("application/x-www-form-urlencoded", RequestBody, ParameterType.RequestBody);
//                var Response = _restClient.Execute(_restRequest);
//                Rest<Dto.Messages> RestResult = new Rest<Dto.Messages>();
//                RestResult = JsonConvert.DeserializeObject<Rest<Dto.Messages>>(Response.Content);
//                return Task.FromResult(RestResult.Data);
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }
//        public Task<bool> GetDeliveries(long RefrenceId)
//        {
//            try
//            {
//                _restClient.BaseUrl = new Uri(_smsConfig.Value.Urls.FirstOrDefault(x => x.Name == "GetDeliveryMessages").Address);
//                var RequestBody = string.Format("username={0}&password={1}&recID={2}",
//                    _smsConfig.Value.Authentication.UserName,
//                    _smsConfig.Value.Authentication.Password,
//                    RefrenceId);
//                _restRequest.Method = Method.POST;
//                _restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
//                _restRequest.AddHeader("postman-token", _smsConfig.Value.Authentication.Token);
//                _restRequest.AddHeader("cache-control", "no-cache");
//                _restRequest.AddParameter("application/x-www-form-urlencoded", RequestBody, ParameterType.RequestBody);
//                var Response = _restClient.Execute(_restRequest);
//                Rest<Dto.Messages> RestResult = new Rest<Dto.Messages>();
//                RestResult = JsonConvert.DeserializeObject<Rest<Dto.Messages>>(Response.Content);
//                _TextMessageService.UpDateDelivery(RefrenceId, RestResult.Value.ToByte().ToBoolean());
//                _dbContext.SaveChanges();
//                return Task.FromResult(RestResult.Value.ToByte().ToBoolean());
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}
