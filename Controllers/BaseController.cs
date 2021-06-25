using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Controllers
{
    public class BaseController<T> : Controller, IController<T> where T : class, new()
    {
        private readonly IMapper _mapper;
        public BaseController(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
