using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using CurrencyExchange.CustomException;

namespace CurrencyExchange.Helper
{
    public static class PersionDate
    {
        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// </summary>
        /// <param name="MildadiDate"></param>
        /// <returns></returns>
        public static string GetShamsi(DateTime MildadiDate)
        {
            try
            {
                DateTime TmpDate;
                bool IsValid = DateTime.TryParse(MildadiDate.ToString(), out TmpDate);
                if (IsValid == false)
                {
                    return null;
                }
                PersianCalendar pc = new PersianCalendar();
                int year = pc.GetYear(MildadiDate);
                int month = pc.GetMonth(MildadiDate);
                int day = pc.GetDayOfMonth(MildadiDate);
                return FormatShamsiDate(year, month.ToString(), day.ToString());
            }
            catch (Exception ex)
            {
                throw new MyException("GetShamsi", ex);
            }
        }
        /// <summary>
        /// تاریخ امروز
        /// </summary>
        /// <returns></returns>
        public static string GetShamsiToday()
        {
            try
            {
                DateTime MildadiDate = DateTime.Now;
                DateTime TmpDate;
                bool IsValid = DateTime.TryParse(MildadiDate.ToString(), out TmpDate);
                if (IsValid == false)
                {
                    return null;
                }
                PersianCalendar pc = new PersianCalendar();
                int year = pc.GetYear(MildadiDate);
                int month = pc.GetMonth(MildadiDate);
                int day = pc.GetDayOfMonth(MildadiDate);
                return FormatShamsiDate(year, month.ToString(), day.ToString());
            }
            catch (Exception ex)
            {
                throw new MyException("GetShamsiToday", ex);
            }
        }
        /// <summary>
        /// تبدیل تاریخ شمسی به میلادی
        /// </summary>
        /// <param name="ShamsiDate"></param>
        /// <returns></returns>
        public static DateTime? GetMiladi(string ShamsiDate)
        {
            try
            {
                if (IsShamsi(ShamsiDate) == false)
                {
                    return null;
                }
                PersianCalendar pc = new PersianCalendar();
                var split = ShamsiDate.Split(char.Parse("/"));
                var Date = pc.ToDateTime(split[0].ToInt(), split[1].ToInt(), split[2].ToInt(), 0, 0, 0, 0);
                return Date;
            }
            catch (MyException ex)
            {
                throw new MyException("GetMiladi", ex);
            }
        }
        /// <summary>
        /// چک کردن اینکه آیا تاریخ شمسی وارد شده درست است یا نه
        /// </summary>
        /// <param name="ShamsiDate"></param>
        /// <returns></returns>
        public static bool IsShamsi(string ShamsiDate)
        {
            if (ShamsiDate.Length != 10)
            {
                return false;
            }
            PersianCalendar pc = new PersianCalendar();
            var split = ShamsiDate.Split(char.Parse("/"));
            try
            {
                var Date = pc.ToDateTime(split[0].ToInt(), split[1].ToInt(), split[2].ToInt(), 0, 0, 0, 0);
                return true;
            }
            catch (MyException)
            {
                return false;
            }
        }
        /// <summary>
        /// تاریخ شمسی را به رشته استاندارد تاریخ شمسی برمیگرداند
        /// </summary>
        /// <param name="ShamsiDate"></param>
        /// <returns></returns>
        private static string FormatShamsiDate(string ShamsiDate)
        {
            try
            {
                if (ShamsiDate.Length != 10)
                {
                    return "";
                }

                var split = ShamsiDate.Split(char.Parse("/"));
                if (split.Length != 2)
                {
                    return "";
                }
                string Ret = "";
                string Month, Day = "";
                Month = split[1];
                Day = split[2];
                Month = Month.Length != 2 ? Month : "0" + Month;
                Day = Day.Length != 2 ? Day : "0" + Day;
                Ret = split[0] + "/" + Month + "/" + Day;
                return Ret;
            }
            catch (MyException ex)
            {
                throw new MyException("FormatShamsiDate", ex);
            }
        }
        /// <summary>
        /// تاریخ شمسی را به رشته استاندارد تاریخ شمسی برمیگرداند
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="Day"></param>
        /// <returns></returns>
        private static string FormatShamsiDate(int Year, string Month, string Day)
        {
            try
            {
                if (Year == 0 || Month.ToInt() == 0 || Day.ToInt() == 0)
                {
                    return "";
                }

                return string.Format("{0}/{1}/{2}",
                                     Year,
                                    (Month = Month.ToInt() <= 9 ? "0" + Month : Month),
                                    (Day = Day.ToInt() <= 9 ? "0" + Day : Day));
            }
            catch (MyException ex)
            {
                throw new MyException("FormatShamsiDate", ex);
            }
        }
    }
}