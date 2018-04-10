using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        Type classType = Type.GetType(className);
        Type baseClass = classType.BaseType;
        sb.AppendLine($"Base Class: {baseClass.Name}");
        MethodInfo[] methodInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (var method in methodInfo)
        {
            sb.AppendLine(method.Name);
        }
        return sb.ToString().Trim();
    }
}

