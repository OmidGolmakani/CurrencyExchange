﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.ApplicationUsers
{
    public class CUApplicationUser
    {
        public CUApplicationUser()
        {

        }
        public string NationalCode { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string UserFullName
        {
            get
            {
                return string.Format("{0} {1}", this.Name, this.Family);
            }
        }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
