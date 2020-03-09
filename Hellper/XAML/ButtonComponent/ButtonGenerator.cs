using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Reflection;
using Hellper.Reflection;

namespace Hellper.XAML.ButtonComponent
{
    public class CustomButton : Button
    {

    }
    public static class ButtonGenerator
    {
        /// <summary>
        /// Create default button
        /// </summary>
        /// <param name="propertyForChanges">property witch must be change</param>
        /// <returns></returns>
        public static Button GetDefaultButton(params PropertyForChangeData[] propertyForChanges)
        {
            if (propertyForChanges == null || propertyForChanges.Length == 0)
                return new Button();
            else
            {
                Button btn = new Button();
                PropertyInfo[] propertys = btn.GetType()
                        .GetProperties(BindingFlags.Public|BindingFlags.Instance)
                            .Where(x=>propertyForChanges.Select(y=>y.Name).ToArray().Contains(x.Name)).ToArray();
                foreach (var item in propertys)
                    item.SetValue(btn,propertyForChanges.Where(x=>x.Name==item.Name).FirstOrDefault().Value);
                return btn;
            }
        }

        /// <summary>
        /// Create async default button
        /// </summary>
        /// <param name="propertyForChange">property witch must be change</param>
        /// <returns></returns>
        public static Task<Button> GetDefaultButtonAsync(params PropertyForChangeData[] propertyForChanges)
        {
            return new Task<Button>(()=>
            {
               return GetDefaultButton(propertyForChanges); 
            });            
        }
    }
}