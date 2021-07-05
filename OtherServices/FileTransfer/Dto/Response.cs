using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyExchange.OtherServices.FileTransfer.Dto
{
    public class Response
    {
        public FtpStatusCode Code { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
