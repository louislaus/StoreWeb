using System;
using System.Reflection;

namespace StoreWeb.Core.Extensions
{
    public  static class EnumExtensions
    {
        public static string ToDescription(this Enum enumeration)
        {
            Type type = enumeration.GetType();
            MemberInfo[] members = type.GetMember(enumeration.CastTo<string>());
            if (members.Length > 0)
            {
                return members[0].ToDescription();
            }
            return enumeration.CastTo<string>();
        }
    }
}
