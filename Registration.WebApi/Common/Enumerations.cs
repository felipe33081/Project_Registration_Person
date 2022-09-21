using System.ComponentModel;
using System.Reflection;

namespace Registration.WebApi.Common
{
    public static class Enumerations
    {
        public static string GetEnumDescription(Enum value)
        {
            if (value == null)
                return null;

            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
                return attributes.First().Description;

            return value.ToString();
        }
    }
}
