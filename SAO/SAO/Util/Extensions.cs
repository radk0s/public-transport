using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAO.Util
{
    public static class Extensions
    {
        private static readonly NumberFormatInfo DecimalSeparatorFormat = new NumberFormatInfo {
            NumberDecimalSeparator = ".",
            NumberGroupSeparator = ","
        };

        public static int GetIntOrDefault(this IDictionary<String, String> dictionary, String key, int defaultValue)
        {
            if (dictionary.ContainsKey(key))
                return int.Parse(dictionary[key]);
            else return defaultValue;
        }

        public static double GetDoubleOrDefault(this IDictionary<String, String> dictionary, String key, double defaultValue)
        {
            if (dictionary.ContainsKey(key))
                return double.Parse(dictionary[key], System.Globalization.NumberStyles.Any, DecimalSeparatorFormat);
            else return defaultValue;
        }
    }
}
