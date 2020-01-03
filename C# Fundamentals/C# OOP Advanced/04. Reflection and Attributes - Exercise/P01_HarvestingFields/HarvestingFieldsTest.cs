 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            string input = Console.ReadLine().ToLower();

            var allFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            while (input != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                        var privateFields = allFields.Where(x => x.IsPrivate).ToArray();
                        ForeachFieldsAndPrint(privateFields, input);
                        break;
                    case "protected":
                        var protectedFields = allFields.Where(x => x.IsFamily).ToArray();
                        ForeachFieldsAndPrint(protectedFields, input);
                        break;
                    case "public":
                        var publicFields = allFields.Where(x => x.IsPublic).ToArray();
                        ForeachFieldsAndPrint(publicFields, input);
                        break;
                    case "all":
                        ForeachFieldsAndPrint(allFields, input);
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private static void ForeachFieldsAndPrint(FieldInfo[] fields, string input)
        {
            if (input == "protected" || input == "all")
            {
                foreach (var field in fields)
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")}" +
                        $" {field.FieldType.Name} {field.Name}");
                }
            }
            else
            {
                foreach (var field in fields)
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}
