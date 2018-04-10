using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{

    public string AnalyzeAcessModifiers(string className)
    {
        Type type = Type.GetType(className);
        FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] publicMethodsInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] privateMethodsInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();

        foreach (var field in fieldsInfo)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var method in privateMethodsInfo.Where(m=>m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }
        foreach (var method in publicMethodsInfo.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }
        return sb.ToString().Trim();
    }
}

