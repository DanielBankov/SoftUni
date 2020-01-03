using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();
        Type type = Type.GetType(className);

        var allFields = type.GetFields((BindingFlags)62);

        var privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name.StartsWith("get"));

        var publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => x.Name.StartsWith("set"));

        foreach (var field in allFields)
        {
            if (field.IsPublic)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
        }

        foreach (var method in privateMethods)
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in publicMethods)
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }
}

