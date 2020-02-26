using System;

namespace Hellper.Models
{
    public class Param<T> : IParam<T>
    {
        public Param(T paramValue, Type paramType, string paramName)
        {
            ParamValue = paramValue;
            ParamType = paramType;
            ParamName = paramName; 
        }
        public T ParamValue { get; set; }
        public Type ParamType { get; set; }
        public String ParamName { get; set; }
    }
}