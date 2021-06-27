using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Selle.WebApp.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [CustomExceptionFilter]
    [CustomAuthorizationFilter]
    //[AnyExceptExceptionFilter]
    [EnableCors("MyCorsPolicy")]
    public class BaseController<T> : ControllerBase
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
