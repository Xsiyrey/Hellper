namespace Hellper.Models
{
    public interface ISettingParams
    {
        IParam<dynamic>[] GetParams();
        bool ChangeProperty<T>(T value, string propertyName);
        IParam<dynamic>[] ParamsEl { get; set; }
    }
}
