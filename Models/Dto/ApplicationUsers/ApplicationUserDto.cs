using CurrencyExchange.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.ApplicationUsers
{
    public class ApplicationUserDto : BaseDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string UserFullName
        {
            get
            {
                return string.Format("{0} {1}", Name, Family);
            }
        }
        public string NationalCode { get; set; }
        public bool NationalCodeConfirmed { get; set; }
        public string Tel { get; set; }
        public bool TelConfirmed { get; set; }
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
