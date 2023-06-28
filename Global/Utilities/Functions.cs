using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCX_Labs.Global.Utilities
{
    public static class Functions
    {
        public static string ReturnCPF(this string PValue)
        {
            if (PValue != null && PValue.Length == 11)
                return PValue.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            return PValue;
        }

        public static string DateTimeToString(DateTime date)
        {

            string day = string.Empty;
            string month = string.Empty;
            string year = date.Year.ToString();

            if (date.Day.ToString().Length < 2)
            {
                day = "0" + date.Day.ToString();
            }
            else
            {
                day = date.Day.ToString();
            }

            if (date.Month.ToString().Length < 2)
            {
                month = "0" + date.Month.ToString();
            }
            else
            {
                month = date.Month.ToString();
            }

            return day + "/" + month + "/" + year;

        }
    }


}