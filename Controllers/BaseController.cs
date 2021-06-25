using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyExchange.Controllers
{
    public abstract class BaseController<T> : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<T> _logger;

        protected BaseController(IMapper mapper,
                                 ILogger<T> logger)
        {
            this._mapper = mapper;
            this._logger = logger;
        }

    }
}
