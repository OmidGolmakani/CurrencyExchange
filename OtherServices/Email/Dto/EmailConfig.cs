using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selle.WebApp.Services.External.Email.Dto
{
    public class EmailConfig
    {
        public MailServer MailServer { get; set; }
        public List<AdminEmail> AdminEmails { get; set; }
        public List<EmailPort> EmailPorts { get; set; }
    }
}
