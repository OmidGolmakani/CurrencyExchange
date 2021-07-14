using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Images
{
    public class CUImageDto
    {
        public long UserId { get; set; }
        public byte ImageTypeId { get; set; }
        public string Description { get; set; }
    }
}
