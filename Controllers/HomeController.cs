using AutoMapper;
using CurrencyExchange.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyExchange.Controllers
{
    public class HomeController : Controller// BaseController<HomeController>, IController<HomeController>
    {
        //private readonly ILogger<HomeController> _logger;
        //private readonly IMapper _mapper;

        public HomeController()
        {
            //_logger = logger;
            //_mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return null;
        }
    }
}
