using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.OtherServices.FileTransfer.Dto
{
    public class MaxSize
    {
        public FileTransfer.Enum.Type.FileType FileType { get; set; }
        public int Size { get; set; }
    }
}
