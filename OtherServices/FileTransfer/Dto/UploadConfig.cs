using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.OtherServices.FileTransfer.Dto
{
    public class UploadConfig
    {
        public string RootUrl { get; set; }
        public OtherServices.FileTransfer.Enum.Type Type { get; set; }
    }
}
