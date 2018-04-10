using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methodInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();

        foreach (var method in methodInfo.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach (var method in methodInfo.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }
        return sb.ToString().Trim();
    }
}

