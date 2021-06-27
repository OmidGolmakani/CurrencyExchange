using AutoMapper;
using CurrencyExchange.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership
{
    public class HomeController : ControllerBase/*BaseController<HomeController>, IController<HomeController>*/
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper, ILogger<HomeController> logger) 
        {
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("test")]
        public IActionResult Index()
        {
            return Ok("");
        }

    }
}
