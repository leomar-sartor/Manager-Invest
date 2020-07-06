using System;

namespace Carteira.Domain.Infra
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ListItemAttribute : Attribute
    {
        public ListItemAttribute(object key, string value)
        {
            Key = key;
            Value = value;
        }
        public object Key { get; set; }
        public string Value { get; set; }
    }
}
