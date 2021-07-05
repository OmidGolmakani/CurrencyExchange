using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.OtherServices.FileTransfer.Dto
{
    public class UploadConfig
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<MaxSize> MaxSize { get; set; }
    }
}
