using System;

namespace EPiProperties.Util
{
    public static class ObjectExtensions
    {
        public static object Cast(this object @object, Type type)
        {
            var result = Convert.ChangeType(@object, type);
            return result;
        }
    }
}