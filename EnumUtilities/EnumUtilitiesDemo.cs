using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    internal class EnumUtilitiesDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("## ENUM UTILITIES DEMO ##\n");

            // Skapa en lista av Enums med hjälp av en extensionmetod:
            var fruits1 = new Fruits().GetAllEnumValues().PrintList("new Fruits().GetAllEnumValues()");
            var fruits2 = Fruits.Apple.GetAllEnumValues().PrintList("Fruits.apple.GetAllEnumValues()");

            // Skapa en lista av Enums med hjälp av en statisk metod:
            var fruits3 = EnumUtilities.GetAllEnumValues<Fruits>().PrintList("GetAllEnumValues<Fruits>");

            // Skapa en lista av strängar.
            var fruits4 = new Fruits().ToListOfStrings().PrintList("ToListOfStrings");

            // Kontrollera om en string har en motsvarande Enum.
            var bool1 = "apple".IsEnum(Fruits.None).Print(@"""apple""");
            var bool2 = "banana".IsEnum(Fruits.None).Print(@"""banana""");
            var bool3 = "orange".IsEnum(Fruits.None).Print(@"""orange""");
            Console.WriteLine();

            // Konvertera string till Enum med ett angivet default-värde.
            var enum1 = "apple".ToEnum(Fruits.None).Print(@"""apple""");
            var enum2 = "banana".ToEnum(Fruits.None).Print(@"""banana""");
            var enum3 = "orange".ToEnum(Fruits.None).Print(@"""orange""");

            Console.ReadKey();
        }
    }

    internal enum Fruits
    {
        None,
        Apple,
        Banana
    }


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

        public static bool IsEnum<T>(this string input, T defaultValue) where T : Enum
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

    internal static class PrintingUtilities
    {
        public static IList<T> PrintList<T>(this IList<T> input, string heading)
        {
            Console.WriteLine($"{heading}:");
            Console.WriteLine($"{{ {string.Join(", ", input)} }}");
            Console.WriteLine();
            return input;
        }

        public static T Print<T>(this T input, string heading)
        {
            Console.Write($"{heading}: ");
            Console.WriteLine(input);
            return input;
        }
    }
}
