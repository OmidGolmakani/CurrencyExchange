using AutoMapper;
using CurrencyExchange.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership.Controllers
{
    public class HomeController : BaseController<HomeController>, IController<HomeController>
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper, ILogger<HomeController> logger) : base(mapper, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }

        public IActionResult Index(object Id = null)
        {
            throw new NotImplementedException();
        }

        public IActionResult Index(Expression<Func<HomeController, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public IActionResult Submit(HomeController data)
        {
            throw new NotImplementedException();
        }
    }
}
