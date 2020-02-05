using agendaInvent.Common.Resources;
using System;
using System.Text.RegularExpressions;

namespace agendaInvent.Common.Validation
{
    public class PhoneAssertionConcern
    {
        public static void AssertIsValid(string phone)
        {
            if (!Regex.IsMatch(phone, @"^(?:(55\d{2})|\d{2})[6-9]\d{8}$", RegexOptions.IgnoreCase))
                throw new Exception(Errors.InvalidPhone);
        }
    }
}