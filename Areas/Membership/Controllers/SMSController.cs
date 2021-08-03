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
            svrSMS.SendSMSWithPattern("1234","09151241208",OtherServices.SMS.Enum.Pattern.type.VerifyPhoneNumber);
            return Ok("");
        }

    }
}
