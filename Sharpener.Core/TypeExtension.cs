using System;

namespace Sharpener.Core
{
    public static class TypeExtension
    {
        public static bool IsPrimitiveOrString(this Type type)
        {
            if (type == typeof(string)) return true;
            return type.IsValueType & type.IsPrimitive;
        }
    }
}