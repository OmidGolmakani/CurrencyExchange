using CurrencyExchange.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyExchange.Models.EnumHelper
{
    public static class Helper
    {
        /// <summary>
        /// Return a List Of T Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        static internal List<EnumListStructure> GetEnumLists<T>()
        {
            if (!typeof(T).IsEnum) // just to be safe
                throw new MyException(string.Format("نوع ارسال شده {0} غیر مجاز می باشد", typeof(T)));
            var q = System.Enum.GetValues(typeof(T)).Cast<T>()
              .Select(x => new EnumListStructure { id = Convert.ToInt32(x), Name = x.ToString() })
              .ToList();
            return q;

        }
        static internal bool EnumValidator<T>(byte Id)
        {
            return GetEnumLists<T>().Select(x => x.id).ToList().Contains(Id);
        }
    }
}
