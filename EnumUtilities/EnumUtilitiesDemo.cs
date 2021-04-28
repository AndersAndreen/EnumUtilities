using System;
using System.Collections.Generic;

namespace EnumUtilities
{
    internal class EnumUtilitiesDemo
    {
        internal enum Fruits
        {
            None,
            Apple,
            Banana
        }

        public static void RunDemo()
        {
            Console.WriteLine("## ENUM UTILITIES DEMO ##\n");

            // Create a list of Enums using an extension method:
            var fruits1 = new Fruits().GetAllEnumValues().PrintList("new Fruits().GetAllEnumValues()");
            var fruits2 = Fruits.Apple.GetAllEnumValues().PrintList("Fruits.apple.GetAllEnumValues()");

            // Create a list of Enums using a static method:
            var fruits3 = global::EnumUtilities.EnumUtilities.GetAllEnumValues<Fruits>().PrintList("GetAllEnumValues<Fruits>");

            // Create a list of strings holding the names of all the enums:
            var fruits4 = new Fruits().ToListOfStrings().PrintList("ToListOfStrings");

            // Check if a string has a corresponding Enum:
            var bool1 = "apple".IsEnum<Fruits>().Print(@"""apple""");
            var bool2 = "banana".IsEnum<Fruits>().Print(@"""banana""");
            var bool3 = "orange".IsEnum<Fruits>().Print(@"""orange""");
            Console.WriteLine();

            // Convert a string to an Enum specifying a default value if no match is found:
            var enum1 = "apple".ToEnum(Fruits.None).Print(@"""apple""");
            var enum2 = "banana".ToEnum(Fruits.None).Print(@"""banana""");
            var enum3 = "orange".ToEnum(Fruits.None).Print(@"""orange""");

            Console.ReadKey();
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
