using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Extensions.Services
{
    internal sealed class Validator_service
    {
        #region E-MAIL
        bool isInValid { get; set; }
        string DomainMapper(Match match)
        {
            var idnMapping = new IdnMapping();
            var domainName = match.Groups[2].Value;
            try
            {
                domainName = idnMapping.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                isInValid = true;
            }
            return match.Groups[1].Value + domainName;
        }
        /// <summary>
        /// Check a mail address
        /// </summary>
        public bool MailAddress(string address)
        {
            isInValid = false;
            if (string.IsNullOrWhiteSpace(address))
            {
                return false;
            }
            else
            {
                try
                {
                    address = Regex.Replace(
                        address, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }

                if (isInValid)
                {
                    return false;
                }
                else
                {
                    try
                    {
                        return Regex.IsMatch(
                            address, @"([a-zA-Z0-9\-\_\.]+)\@([a-zA-Z0-9\-\_\.]{3,})\.([a-zA-Z]{2,4})",
                            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                    }
                    catch (RegexMatchTimeoutException)
                    {
                        return false;
                    }
                }
            }
        }
        #endregion E-MAIL
    }
}
