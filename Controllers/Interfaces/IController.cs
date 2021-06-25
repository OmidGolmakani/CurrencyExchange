using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Controllers
{
    public interface IController<T>
    {
        [HttpGet]
        IActionResult Index(object Id = null);
        [HttpPatch]
        IActionResult Index(Expression<Func<T, bool>> expression = null);
        [HttpPost]
        IActionResult Submit(T data);
        [HttpPost]
        IActionResult Delete();
    }
}
