﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.AuthUserItems
{
    public class AuthUserItemDto : Base.BaseDto
    {
        public long Id { get; set; }
        public int AuthItemId { get; set; }
        public long UserId { get; set; }
    }
}
