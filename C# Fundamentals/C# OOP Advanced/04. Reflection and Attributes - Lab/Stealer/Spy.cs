using System;
using System.Reflection;
using System.Text;

public class Spy 
{
    public string StealFieldInfo(string className, params string[] inputFields)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {className}");

        Type type = Type.GetType(className);

        var hackerInstance = Activator.CreateInstance(type);

        for (int i = 0; i < inputFields.Length; i++)
        {
            FieldInfo field = type.GetField(inputFields[i],
                BindingFlags.Public | 
                BindingFlags.Instance | 
                BindingFlags.Static |
                BindingFlags.NonPublic);

            var value = field.GetValue(hackerInstance);

            sb.AppendLine($"{field.Name} = {value}");
        }

        return sb.ToString().TrimEnd();
    }
}

