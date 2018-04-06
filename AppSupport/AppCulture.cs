using System;
using System.Globalization;
using System.Windows.Forms;

namespace DevExpress.Common.Culture
{
    public class AppCulture
    {
        /// <summary>
        /// Init culture
        /// </summary>
        public static void InitCulture()
        {
            CultureInfo cul = new CultureInfo("en-US");
            //cul.NumberFormat.CurrencyDecimalSeparator = ".";
            //cul.NumberFormat.CurrencyGroupSeparator = ",";
            //cul.NumberFormat.NumberDecimalSeparator = ".";
            //cul.NumberFormat.NumberGroupSeparator = ",";
            //cul.NumberFormat.PercentDecimalSeparator = ".";
            //cul.NumberFormat.PercentGroupSeparator = ",";
            cul.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Application.CurrentCulture = cul;
        }

        /// <summary>
        /// Khởi tạo CultureInfo theo tên culture
        /// </summary>
        /// <param name="culture_name"></param>
        public static void InitCulture(string culture_name)
        {
            CultureInfo cul = new CultureInfo(culture_name);
            //cul.NumberFormat.CurrencyDecimalSeparator = ".";
            //cul.NumberFormat.CurrencyGroupSeparator = ",";
            //cul.NumberFormat.NumberDecimalSeparator = ".";
            //cul.NumberFormat.NumberGroupSeparator = ",";
            //cul.NumberFormat.PercentDecimalSeparator = ".";
            //cul.NumberFormat.PercentGroupSeparator = ",";
            cul.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Application.CurrentCulture = cul;
        }
    }
}