using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selle.WebApp.Services.External.Email.Enum
{
    public class EmailConfig
    {
        public enum EmailPort
        {
            POP3 = 995,
            IMAP = 993,
            SMTP = 587
        }
    }
}
