using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Images
{
    public class CUImageDto
    {
        public Nullable<long> Id { get; set; }
        public long UserId { get; set; }
        public byte ImageTypeId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
    }
}
