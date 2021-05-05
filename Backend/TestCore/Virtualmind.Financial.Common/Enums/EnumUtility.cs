using System;
namespace Virtualmind.Financial.Common.Enums
{
    public static class EnumUtility
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
