using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Base
{
    public class BaseDto : EmptyBaseDto
    {
        public BaseDto()
        {
            SetDefaultValues();
        }
        [JsonIgnore]
        public virtual bool Deleted { get; set; }
        [JsonIgnore]
        public virtual bool Published { get; set; }
        [JsonIgnore]
        public virtual DateTime? CreateDate { get; set; }
        [JsonIgnore]
        public virtual DateTime? LastModifyDate { get; set; }
        private void SetDefaultValues()
        {
            var Id = this.GetType().GetProperty("Id");
            if (Id != null)
            {
                var value = Id.GetValue(this, null);
                if (Convert.ToInt64(value) == 0)
                {
                    this.Published = true;
                    if (CreateDate == null) CreateDate = DateTime.Now;
                }
                else
                {
                    if (LastModifyDate == null) LastModifyDate = DateTime.Now;
                }
            }
        }
    }
}
