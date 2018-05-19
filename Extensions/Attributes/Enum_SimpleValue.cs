using System;

namespace Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class SimpleValue : Attribute
    {
        public object Value { get; private set; }
        public SimpleValue(object value)
        {
            Value = value;
        }
    }
}
