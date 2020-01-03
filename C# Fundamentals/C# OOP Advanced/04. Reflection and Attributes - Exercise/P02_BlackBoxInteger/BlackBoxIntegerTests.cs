namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            var instance = Activator.CreateInstance(type, true);
            string[] input = Console.ReadLine().Split('_');

            while (input[0] != "END")
            {
                MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(x =>x.Name == input[0]);

                method.Invoke(instance, new object[] { int.Parse(input[1]) });

                var result = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(f => f.Name == "innerValue").GetValue(instance);

                Console.WriteLine(result);
                input = Console.ReadLine().Split('_');
            }
        }
    }
}
