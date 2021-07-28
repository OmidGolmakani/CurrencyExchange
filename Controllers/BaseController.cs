using AutoMapper;
using CurrencyExchange.Data;
using CurrencyExchange.Filter;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    //[CustomExceptionFilter]
    [CustomAuthorizationFilter]
    //[AnyExceptExceptionFilter]
    [AnyFilter]
    public class BaseController<T> : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<T> _logger;
        private readonly ApplicationDbContext dbContext;

        public BaseController(IMapper mapper,
                              ILogger<T> logger,
                              ApplicationDbContext DbContext)
        {
            this._mapper = mapper;
            this._logger = logger;
            this.dbContext = DbContext;
        }
        public BaseController(IMapper mapper,
                              ApplicationDbContext DbContext)
        {
            this._mapper = mapper;
            this.dbContext = DbContext;
        }
        public BaseController()
        {
            
        }

    }
}
