using System;

namespace Hellper.Models
{
    public interface IParam<T>
    {
        T ParamValue { get; set; }
        Type ParamType { get; set; }
        String ParamName { get; set; }
    }
}