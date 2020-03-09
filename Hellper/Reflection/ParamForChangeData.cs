using System;

namespace Hellper.Reflection
{
    public class PropertyForChangeData
    {
        public string Name { get; set; }
        public object Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">parametor name</param>
        /// <param name="value">new value</param>
        public PropertyForChangeData(string name, object value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name can't be null or empty", nameof(name));

            Name = name;
            Value = value;
        }
    }
}