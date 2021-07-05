using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.AppSettings.Dto.EmailConfigs
{
    public class ConfigDto
    {
        public string OutgoingMailServer { get; set; }
        public string IncomingMailServer { get; set; }
        public List<EmailPortDto> EmailPorts { get; set; } = new List<EmailPortDto>();
        public List<AdminEmailDto> AdminEmails { get; set; } = new List<AdminEmailDto>();

    }
}
