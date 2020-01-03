using System;
using System.Linq;
using System.Reflection;

namespace Coding_Tracker
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(attr => attr.AttributeType == typeof(SoftUniAttribute)))
                {
                    var attrs = method.GetCustomAttributes(false);

                    foreach (SoftUniAttribute attr in attrs)
                    {
                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}
