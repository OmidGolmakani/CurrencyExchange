using CurrencyExchange.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership.Interfaces
{
    public interface IController<T,T1> where T : class
    {
        public Task<IActionResult> Add(T entity);
        public Task<IActionResult> Edit(T entity);
        public Task<IActionResult> Delete(T1 Id);
        public Task<IActionResult> GetAll();
        public Task<IActionResult> GetById(T1 Id);

    }
}
