using CurrencyExchange.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.ApplicationUsers
{
    public class CUserLoginDto : BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public override bool Published { get => base.Published; set => base.Published = value; }
        [JsonIgnore]
        public override bool Deleted { get => base.Deleted; set => base.Deleted = value; }
        [JsonIgnore]
        public override DateTime? CreateDate { get => base.CreateDate; set => base.CreateDate = value; }
        [JsonIgnore]
        public override DateTime? LastModifyDate { get => base.LastModifyDate; set => base.LastModifyDate = value; }
    }
}
