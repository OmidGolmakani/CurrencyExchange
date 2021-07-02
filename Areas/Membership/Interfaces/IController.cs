using CurrencyExchange.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership.Interfaces
{
    public interface IController<T> where T : class, new()
    {
        public Task<IActionResult> Add(T entity);
        public Task<IActionResult> Edit(T entity);
        public Task<IActionResult> Delete(object Id);
        public Task<IActionResult> GetAll();
        public Task<IActionResult> GetById(object Id);

    }
}
