using AutoMapper;
using CurrencyExchange.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership
{
    public abstract class AccountController : BaseController<AccountController>
    {

        private readonly IMapper _mapper;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IMapper mapper,
                                 ILogger<AccountController> logger)
            : base(mapper, logger)
        {
            this._mapper = mapper;
            this._logger = logger;
        }
        [HttpGet("GetAccounts")]
        public IActionResult Index()
        {
            return null;
        }
    }
}
