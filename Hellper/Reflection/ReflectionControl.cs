using System;

namespace Hellper.Reflection
{
    public static class ReflectionControl
    {
        /// <summary>
        /// Execute changed of element property
        /// </summary>
        /// <returns>status of execute</returns>
        public static bool ChangeElementProperty(
            object obj, PropertyForChangeData property)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            if (property is null)
                throw new ArgumentNullException(nameof(property));

            try
            {
                obj.GetType().GetProperty(property.Name).SetValue(obj, property.Value);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}