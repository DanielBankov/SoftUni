using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type type = Type.GetType(className);

        var getMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
            .Where(x => x.Name.StartsWith("get"));

        var setMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
            .Where(x => x.Name.StartsWith("set"));

        foreach (var method in getMethods)
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in setMethods)
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");

        }
        return sb.ToString().TrimEnd();
    }
}

