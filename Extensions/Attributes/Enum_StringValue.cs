using System;

namespace Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class StringValue : Attribute
    {
        public string Value { get; private set; }
        public StringValue(string value)
        {
            Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class SimpleValue : Attribute
    {
        public object Value { get; private set; }
        public SimpleValue(object value)
        {
            Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class ComplexValue : Attribute
    {
        public object Value { get; private set; }
        public Type ValueType { get; private set; }
        public ComplexValue(object value, Type type)
        {
            Value = value;
            ValueType = type;
        }
    }
}
