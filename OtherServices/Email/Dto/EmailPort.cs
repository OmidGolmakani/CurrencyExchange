using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selle.WebApp.Services.External.Email.Dto
{
    public class EmailPort
    {
        public Enum.EmailConfig.EmailPort Name { get; set; }
        public int Port { get; set; }
    }
}
