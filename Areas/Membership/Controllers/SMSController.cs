using AutoMapper;
using CurrencyExchange.Controllers;
using CurrencyExchange.OtherServices.SMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership
{
    public class SMSController : ControllerBase/*BaseController<HomeController>, IController<HomeController>*/
    {
        private readonly SMSService svrSMS;

        public SMSController(OtherServices.SMS.Services.SMSService SvrSMS)
        {
            svrSMS = SvrSMS;
        }
        [HttpPost("SendSMSWithPattern")]
        public IActionResult Index()
        {
            svrSMS.SendSMSWithPattern(new OtherServices.SMS.Dto.SendWithPattern()
            {
                toNum="+989151241208",
                inputData=  new OtherServices.SMS.Dto.InputData() { smstext= "1234" },
            }, OtherServices.SMS.Enum.Pattern.type.VerifyPhoneNumber);
            return Ok("");
        }

    }
}
