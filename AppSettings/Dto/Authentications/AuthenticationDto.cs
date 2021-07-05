using CurrencyExchange.Dto.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.AppSettings.Dto.Authentications
{
    public class AuthenticationDto
    {
        public string SecretKey { get; set; }
        public int ExpiryTime { get; set; }
        public List<string> ValidIssuers { get; set; }
        public string ValidAudience { get; set; }
        public Google Google { get; set; }
    }

}
