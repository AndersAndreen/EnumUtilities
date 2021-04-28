using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumUtilities
{
    internal static class EnumUtilities
    {
        public static List<T> GetAllEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static List<T> GetAllEnumValues<T>(this T enumInput) where T : Enum
        {
            return Enum.GetValues(enumInput.GetType()).Cast<T>().ToList();
        }

        public static List<string> ToListOfStrings(this Enum enumInput)
        {
            return Enum.GetNames(enumInput.GetType()).ToList();
        }

        public static bool IsEnum<T>(this string input) where T : Enum
        {
            return Enum.TryParse(typeof(T), input, true, out var output);
        }

        public static T ToEnum<T>(this string input, T defaultValue) where T : Enum
        {
            return Enum.TryParse(typeof(T), input, true, out var output)
                ? (T)output
                : defaultValue;
        }
    }
}
