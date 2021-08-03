using AutoMapper;
using CurrencyExchange.Controllers;
using CurrencyExchange.OtherServices.SMS.Services;
using CurrencyExchange.OtherServices.SMS.Services.MeliPayamak;
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
        private readonly SendMessageService svrSMS;

        public SMSController(OtherServices.SMS.Services.MeliPayamak.SendMessageService SvrSMS)
        {
            svrSMS = SvrSMS;
        }
        [HttpPost("SendSMSWithPattern")]
        public IActionResult Index()
        {
            return Ok(svrSMS.SendMessage("09151241208", "تست"));
        }

    }
}
