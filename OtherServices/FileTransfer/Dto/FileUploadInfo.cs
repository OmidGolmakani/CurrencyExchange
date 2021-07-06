using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CurrencyExchange.OtherServices.FileTransfer.Enum.Type;

namespace CurrencyExchange.OtherServices.FileTransfer.Dto
{
    public class FileUploadInfo
    {
        public FileType FileType { get; set; }
        public string Exctention { get; set; }
        public long Size { get; set; }
        public Response Response { get; set; }
    }
}
