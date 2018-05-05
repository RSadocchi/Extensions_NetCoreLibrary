using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    public static class Tools
    {

        public static string RandomCodeGenerator(int Length = 5, bool LowerCase = true, bool UpperCase = true, bool Numbers = true, bool SpecialChars = false)
        {
            string lowers = "abcdefghijklmnopqrstuvwxyz";
            string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string specials = "£$&%@#-_!*+§°ç|";
            string chars = string.Empty;

            Length = Length < 3 ? 3 : Length;

            if (!LowerCase && !UpperCase && !Numbers && !SpecialChars)
            {
                LowerCase = !LowerCase;
                UpperCase = !UpperCase;
                Numbers = !Numbers;
            }

            chars += LowerCase ? string.Format($"{lowers}") : string.Empty;
            chars += UpperCase ? string.Format($"{uppers}") : string.Empty;
            chars += Numbers ? string.Format($"{numbers}") : string.Empty;
            chars += SpecialChars ? string.Format($"{specials}") : string.Empty;

            Random rnd = new Random();
            return new string(Enumerable.Repeat(chars, Length).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        public static int RandomNumberGenerator(int startIncluded, int endIncluded)
        {
            endIncluded++;
            Random rnd = new Random();
            return rnd.Next(startIncluded, endIncluded);
        }
    }
}
