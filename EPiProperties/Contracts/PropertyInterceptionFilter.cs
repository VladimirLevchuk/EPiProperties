using System.Reflection;

namespace EPiProperties.Contracts
{
    public class PropertyInterceptionFilter
    {
        public virtual bool NeverIntercept(PropertyInfo property)
        {
            var result = property.DeclaringType.AssemblyQualifiedName.ToLower().StartsWith("EPiServer".ToLower());
            return result;
        }
    }
}