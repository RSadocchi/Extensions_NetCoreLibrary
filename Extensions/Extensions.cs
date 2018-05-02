using Extensions.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Extensions
{
    public static class Extensions
    {
        public static string GetMD5Hash(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;
            var sb = new StringBuilder();
            var csp = new MD5CryptoServiceProvider();
            var bytes = csp.ComputeHash(Encoding.UTF8.GetBytes(source));
            bytes.ToList().ForEach(b => { sb.Append(b.ToString("x2")); });
            return sb.ToString();
        }


        public static bool IsEven(this int num)
        {
            return (num % 2 == 0 ? true : false);
        }
        public static bool IsEven(this long num)
        {
            return (num % 2 == 0 ? true : false);
        }
        public static bool IsEven(this double num)
        {
            return (num % 2 == 0 ? true : false);
        }
        public static bool IsEven(this float num)
        {
            return (num % 2 == 0 ? true : false);
        }
        public static bool IsEven(this short num)
        {
            return (num % 2 == 0 ? true : false);
        }
        public static bool IsEven(this decimal num)
        {
            return (num % 2 == 0 ? true : false);
        }

        public static bool ContainNumbers(this string source)
        {
            return Regex.IsMatch(source, @"\d");
        }

        public static bool ContainsUpperCaseLetters(this string source)
        {
            return Regex.IsMatch(source, @"[A-Z]");
        }

        public static string ToFormattedMoneyString(this decimal val, CultureInfo culture = null)
        {
            var rtn = string.Empty;
            if (culture == null)
                culture = CultureInfo.CurrentUICulture;
            rtn = string.Format(new Formatter_service(culture), "{0:C2}", val);

            return rtn;
        }

        public static bool IsValidEmailAddress(this string email)
        {
            return (new Validator_service()).MailAddress(email);
        }
    }
}
