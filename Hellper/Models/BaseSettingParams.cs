using System;
using System.Collections;
using System.Linq;

namespace Hellper.Models
{
    public class BaseSettingParams : ISettingParams
    {
        public BaseSettingParams()
        {

        }

        protected object[] LoadParams()
        {
            Type t = GetType();
            var property = t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Where(x => x.Name.Contains("params"))
                .Select(x => Init("", x.Name))
                    .ToArray();
            ParamsEl = new ArrayList(property);
            return null;
        }
        public ArrayList ParamsEl { get; set; }
        private ArrayList paramsEl;

        public static Param<T> Init<T>(T param, string paramName)
        {
            return new Param<T>()
            {
                ParamValue = param,
                ParamType = typeof(T),
                ParamName = paramName
            };
        }
    }

    public class Param<T>
    {
        public T ParamValue { get; set; }
        public Type ParamType { get; set; }
        public String ParamName { get; set; }
    }
}
