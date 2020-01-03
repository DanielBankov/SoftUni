using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type type = Type.GetType(className);

        var privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().TrimEnd();
    }
}

