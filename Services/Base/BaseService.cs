using Microsoft.AspNetCore.Cors;
using Selle.WebApp.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Services
{
    [CustomExceptionFilter]
    [EnableCors("MyCorsPolicy")]
    public class BaseService
    {
    }
}
