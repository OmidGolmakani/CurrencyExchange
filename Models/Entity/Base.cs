using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    public class Base
    {
        public Base()
        {
            SetDefaultValues();
        }
        public bool Deleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        private void SetDefaultValues()
        {
            var Id = this.GetType().GetProperty("Id");
            if (Id != null)
            {
                var value = Id.GetValue(this, null);
                if (Convert.ToInt64(value) == 0)
                {
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
