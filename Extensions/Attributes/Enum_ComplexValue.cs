using System;

namespace Extensions.Attributes
{
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
