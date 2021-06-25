using AutoMapper;
using CurrencyExchange.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Services
{
    public class BaseDataService : BaseService
    {
        protected IMapper Mapper;


        public BaseDataService(IMapper Mapper)
        {
            this.Mapper = Mapper;
        }
    }
}
