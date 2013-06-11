using System;

namespace EPiProperties.Util
{
    public static class ObjectExtensions
    {
        public static object Cast(this object @object, Type type)
        {
            if (@object == null)
            {
                return null;
            }

            return @object.GetType().Is(type) ? @object : null;
        }
    }
}