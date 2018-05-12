using Extensions.Attributes;
using System;
using System.Reflection;

namespace Extensions.Enum
{
    public static class Extensions
    {
        public static string GetStringValue<T>(this T source) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) return null;
            MemberInfo info = typeof(T).GetField(System.Enum.GetName(typeof(T), source));
            StringValue value = (StringValue)Attribute.GetCustomAttribute(info, typeof(StringValue));
            if (value == null) return null;
            return value.Value;
        }

        public static TValue GetComplexValue<T, TValue>(this T source)
            where T : struct, IConvertible
            where TValue : Type
        {
            if (!typeof(T).IsEnum) return null;
            MemberInfo info = typeof(T).GetField(System.Enum.GetName(typeof(T), source));
            ComplexValue value = (ComplexValue)Attribute.GetCustomAttribute(info, typeof(ComplexValue));
            if (value == null) return null;
            if (value.ValueType != null && value.ValueType != typeof(TValue))
                throw new InvalidCastException($"Value is type of '{value.ValueType.GetType()}', cannot be casted in {typeof(TValue)}");
            return (TValue)value.Value;
        }
    }
}
