using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Core.Extensions
{
    public static class Extension
    {
        // girilen string boş mu ya da girilen uzunluktan uzun mu kontrol etme
        public static bool ControlNullOrWhiteSpaceAndLength(this string value, int length)
        {
            return (!string.IsNullOrWhiteSpace(value) && value.Length < length);
        }


        // girilen ifade sayılardan mı oluşuyor
        public static bool NumberCheckV2(string value)

        {
            return Regex.IsMatch(value, "^[0-9]*$");

        }

        public static bool SpaceControl(this string metin)
        {
            return string.IsNullOrEmpty(metin);
        }

        public static bool NumericControl(this string metin)
        {
            return metin.Any(char.IsDigit);
        }

        public static bool LiteralControl(this string metin)
        {
            return metin.Any(char.IsLetter);
        }

        public static bool SpaceOrNull(this string s)
        {
            return (!string.IsNullOrWhiteSpace(s));
        }

        public static bool TextControl(params string[] inputs)
        {
            foreach (var item in inputs)
            {
                if (!SpaceOrNull(item))
                {
                    return false;
                }
            }
            return true;
        }

        //sql injection
        public static bool SqlControl(params string[] inputs)
        {
            //örnek sqli inputu = Deneme'; drop table DenemeTablosu-- 
            foreach (var input in inputs)
            {
                if (input.Contains(";") || input.Contains("'") || input.Contains("--") || input.Contains("/*") || input.Contains("*/") || input.Contains("xp_"))
                {
                    return false;
                }
            }
            return true;
        }

        // girilen tarihi kontrol etme
        public static bool TarihDogruMu(this string input)
        {
            DateTime date;
            return DateTime.TryParse(input, out date);
        }

        public static bool IsNullOrEmpty(this string value)
        => string.IsNullOrEmpty(value?.Trim());
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            if (list is null || list.Count == 0) return true;
            return false;
        }

        public static bool IsPastDate(this DateTime date)
        {
            return date.Date < DateTime.Now.Date;
        }
        public static bool IsNullOrEmpty(params string[] values)
        {
            foreach (string value in values)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool SifreTekrariKontrol(string password, string passwordAgain)
        {
            return password != passwordAgain;
        }

        public static bool MailMi(string mail)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(mail, emailPattern);
        }
        public static bool SayiVarmi(params string[] values)
        {
            bool varMi = false;
            foreach (string metin in values)
            {
                if (Regex.IsMatch(metin, @"\d"))
                {
                    varMi = true;
                }
            }
            return varMi;
        }

        public static bool OzelKarakterVarMi(params string[] values)
        {
            bool varMi = false;
            foreach (string metin in values)
            {
                if (Regex.IsMatch(metin, @"[!@#$%^&*()_+{}[]:;'""|<>,./\]"))
                {
                    varMi = true;
                }
            }
            return varMi;
        }
        public static bool SifreFormatKontrol(string password)
        {
            bool kontroldenGectiMi = true;

            bool ozelKarakterVarMi = Regex.IsMatch(password, @"[!@#$%^&*()_+=\[{\]};:<>|./?\\,]");

            if (!password.Any(char.IsUpper))
            {
                kontroldenGectiMi = false;
            }
            if (password.Count() < 8 || ozelKarakterVarMi == false)
            {
                kontroldenGectiMi = false;
            }



            return kontroldenGectiMi;
        }
        public static bool BeAValidPhoneNumber(string phoneNumber)
        {
            const string pattern = @"^\d{10}$";
            return !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, pattern);
        }
        public static bool IsNumeric(string input)
        {
            return double.TryParse(input, out _);
        }
        public static bool IsBetween0And100(string input)
        {
            if (int.TryParse(input, out var parsedScore))
            {
                return parsedScore >= 0 && parsedScore <= 100;
            }
            return false;
        }
    }
}
