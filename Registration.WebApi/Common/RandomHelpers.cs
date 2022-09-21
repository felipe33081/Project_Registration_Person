﻿using Newtonsoft.Json;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;


namespace Registration.WebApi.Common
{
    public static class RandomHelpers
    {
        static readonly HttpClient client = new HttpClient();

        public class Location
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        public static Exception GetInnerException(Exception e)
        {
            while (e.InnerException != null) e = e.InnerException;
            return e;
        }

        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static bool ValidateCPFCNPJ(string documentNumber)
        {
            var cpfcnpj = documentNumber;

            if (string.IsNullOrEmpty(cpfcnpj))
                return false;
            var d = new int[14];
            var v = new int[2];
            int j, i, soma;

            var soNumero = Regex.Replace(cpfcnpj, "[^0-9]", string.Empty);

            //verificando se todos os numeros são iguais
            if (new string(soNumero[0], soNumero.Length) == soNumero) return false;

            // se a quantidade de dígitos numérios for igual a 11
            // iremos verificar como CPF
            switch (soNumero.Length)
            {
                case 11:
                    for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(soNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[9] & v[1] == d[10]);
                case 14:
                    const string sequencia = "6543298765432";
                    for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(soNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 11 + i; j++)
                            soma += d[j] * Convert.ToInt32(sequencia.Substring(j + 1 - i, 1));

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[12] & v[1] == d[13]);
                default:
                    return false;
            }
        }


        public static int GetAge(DateTime bornDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bornDate.Year;
            if (bornDate > today.AddYears(-age))
                age--;

            return age;
        }

        public static DateTimeOffset GetBrasiliaDateTime()
        {
            TimeZoneInfo timeZone;
            try
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            }
            catch
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            }
            return TimeZoneInfo.ConvertTime(DateTimeOffset.Now, timeZone);
        }

        public static DateTimeOffset ConvertBrasiliaDateTime(DateTimeOffset date)
        {
            try
            {
                TimeZoneInfo timeZone;
                try
                {
                    timeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
                }
                catch
                {
                    timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                }
                return TimeZoneInfo.ConvertTime(date, timeZone);
            }
            catch
            {
                return date;
            }
        }

        public static DateTimeOffset ConvertToCompareDate(DateTimeOffset date)
        {
            try
            {
                TimeZoneInfo timeZone;
                try
                {
                    timeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
                }
                catch
                {
                    timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                }
                var brazilDate = new DateTimeOffset(date.DateTime, new TimeSpan(timeZone.BaseUtcOffset.Hours, 0, 0));
                return brazilDate.ToUniversalTime();
            }
            catch
            {
                return date;
            }
        }

        public static DateTimeOffset? StringToDateTimeOffset(string date)
        {
            DateTimeOffset converted;
            if (DateTimeOffset.TryParse(date, out converted))
            {
                return converted;
            }
            return null;
        }

        public static int? StringToInt(string integer)
        {
            int converted;
            if (int.TryParse(integer, out converted))
            {
                return converted;
            }
            return null;
        }

        public static long? StringToLong(string integer)
        {
            long converted;
            if (long.TryParse(integer, out converted))
            {
                return converted;
            }
            return null;
        }

        public static Location GetLatLng(string street, string number, string cityName, string stateAbrev, string key)
        {

            try
            {
                var url =
                    $"https://maps.googleapis.com/maps/api/geocode/json?address={street}, {number}, {cityName} - {stateAbrev}&key={key}";
                var response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync();
                dynamic obj = JsonConvert.DeserializeObject(content.Result);
                string test = obj.ToString();
                if (!test.Contains("UNKNOWN") && !test.Contains("ZERO_RESULTS"))
                {
                    dynamic location = obj.results[0].geometry.location;

                    return new Location
                    {
                        Latitude = location.lat,
                        Longitude = location.lng
                    };
                }
                return null;
            }
            catch
            {
                return null;
            }

        }

        public static void WriteCSVLocal<T>(IEnumerable<T> items, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join("; ", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join("; ", props.Select(p => p.GetValue(item, null))));
                }
            }
        }

        public static MemoryStream WriteCSV<T>(IEnumerable<T> items, string separator)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StringWriter())
            {
                writer.WriteLine(string.Join("; ", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join("; ", props.Select(p => p.GetValue(item, null))));
                }

                var stream = new MemoryStream();
                using (StreamWriter writer2 = new StreamWriter(stream))
                {
                    writer2.Write(writer);
                    writer2.Flush();
                    stream.Position = 0;
                    return stream;
                }
            }

        }

        public static string GetEnumDescription(Enum value)
        {
            return GetEnumDescription(value, "");
        }

        public static string GetEnumDescription(Enum value, string enumPrefix)
        {
            if (value == null)
            {
                return default(string);
            }

            FieldInfo fi = value.GetType().GetField(String.Format("{1}{0}", value.ToString(), enumPrefix));

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            return value.ToString();
        }

        public static string RemoveAccents(string withAccents)
        {
            if (!string.IsNullOrEmpty(withAccents))
                return new string(withAccents
                    .Normalize(NormalizationForm.FormD)
                    .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    .ToArray());
            return "";
        }


        public static decimal RandomDecimal(decimal min, decimal max)
        {
            var rnd = new Random();
            decimal d = (decimal)(rnd.NextDouble()) * (max - min) + min;
            return decimal.Round(d, 2);
        }

        public static string RandomStringWithoutVowels()
        {
            const string chars = "BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }


        public static string RandomString(int size)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[size];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        public static double CalculateDistance(double initialLatitude, double initialLongitude,
            double finalLatitude, double finalLongitude)
        {
            var d1 = initialLatitude * (Math.PI / 180.0);
            var num1 = initialLongitude * (Math.PI / 180.0);
            var d2 = finalLatitude * (Math.PI / 180.0);
            var num2 = finalLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                    Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
