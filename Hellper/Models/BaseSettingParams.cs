using System;
using System.Linq;
using System.Reflection;
using Hellper.Attributes;

namespace Hellper.Models
{
    public class BaseSettingParams : ISettingParams
    {
        public BaseSettingParams()
        {
            LoadParams();
        }
        public void LoadParams()
        {
            ParamsEl = GetParams();
        }
        public IParam<dynamic>[] GetParams()
        {
            return GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(x => x.IsDefined(typeof(SettingsPropertyAttribute)))
                        .Select(x => new Param<dynamic>(x.GetValue(this), x.PropertyType, x.Name))
                            .ToArray();
        }
        public bool ChangeProperty<T>(T value, string propertyName)
        {
            var property = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.Name == propertyName).FirstOrDefault();
            if (property == null)
                return false;
            property.SetValue(this, value);
            var param = ParamsEl.Where(x => x.ParamName == propertyName).FirstOrDefault();
            param.ParamValue = value;
            return true;
        }
        public IParam<dynamic>[] ParamsEl { get; set; }
    }
}
