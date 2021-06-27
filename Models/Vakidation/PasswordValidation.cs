using CurrencyExchange.CustomException;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Vakidation
{
    public class PasswordValidation
    {
        internal bool Validation(string Password)
        {
            try
            {
                List<string> Err = new List<string>();
                Err.Add("طول رمز عبور  باید حداقل 10 کاراکتر باشد");
                Err.Add("در رمز عبور باید از حروف غیر الفبایی مانند @ استفاده نمایید");
                Err.Add("رمز عبور باید حداقل شامل یک عدد باشد");
                Err.Add("رمز عبور باید شامل یک حرف بزرگ باشد");
                Err.Add("رمز عبور باید شامل یک حرف کوچک باشد");
                MyException ex = new MyException(JsonConvert.SerializeObject(string.Join(Environment.NewLine, Err)));
                if (Password.Length == 0)
                {
                    throw ex;
                }
                if (Password.Length < 10) throw new MyException(JsonConvert.SerializeObject("طول رمز عبور  باید حداقل 10 کاراکتر باشد"));
                if (Regex.Match(Password, @"[^a-zA-Z\d\s:]").Success == false) throw new MyException(JsonConvert.SerializeObject("در رمز عبور باید از حروف غیر الفبایی مانند @ استفاده نمایید"));
                if (Regex.Match(Password, @"[\d]").Success == false) throw new MyException(JsonConvert.SerializeObject("رمز عبور باید حداقل شامل یک عدد باشد"));
                if (Password.Any(char.IsUpper) == false) throw new MyException(JsonConvert.SerializeObject("رمز عبور باید شامل یک حرف بزرگ باشد"));
                if (Password.Any(char.IsLower) == false) throw new MyException(JsonConvert.SerializeObject("رمز عبور باید شامل یک حرف کوچک باشد"));
                return true;
            }
            catch (MyException ex)
            {
                throw ex;
            }
        }
    }
}
