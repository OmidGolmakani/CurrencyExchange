﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Enum
{
    public class Order : Base
    {
        public enum Status
        {
            AwaitingConfirmation = 1,
            Confirmation = 2
        }
    }
}