using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SgConAPI.Utils
{
    public static class Utilities
    {
        public static T GetEnumValueFromEnumMember<T>(string description)
        {
            var type = typeof(T);
            if (!type.GetTypeInfo().IsEnum)
                throw new ArgumentException();
            var fields = type.GetFields();
            var field = fields.SelectMany(f => f.GetCustomAttributes(
                               typeof(EnumMemberAttribute), false), (
                                   f, a) => new { Field = f, Att = a }).SingleOrDefault(a => ((EnumMemberAttribute)a.Att)
                                       .Value == description);
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }

        public static string FormatStringDocument(this string value)
        {
            value = value.Replace(".", string.Empty);
            value = value.Replace(",", string.Empty);
            value = value.Replace("-", string.Empty);
            value = value.Replace("/", string.Empty);
            value = value.Replace(@"\", string.Empty);
            value = value.Replace("_", string.Empty);

            return value;
        }
    }
}
