using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebUI.Helpers;

public static class Extensions
{
    public static string GetEnumDisplayName(this Enum enumType)
    {
        return enumType.GetType().GetMember(enumType.ToString())
                       .First()
                       .GetCustomAttribute<DisplayAttribute>()
                       .Name;
    }
}
