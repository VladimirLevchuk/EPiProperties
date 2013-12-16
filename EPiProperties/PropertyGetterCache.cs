using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using EPiProperties.Contracts;

namespace EPiProperties
{
    public class PropertyGetterCache
    {
        private readonly MemoryCache _cache = new MemoryCache(typeof(PropertyGetterCache).FullName);

        public virtual string GetKey(PropertyInfo propertyInfo)
        {
            var result = propertyInfo.DeclaringType.AssemblyQualifiedName + "->" + propertyInfo.Name;
            return result;
        }

        public virtual IEnumerable<IEPiPropertyGetter> AddOrGet(PropertyInfo property,
            Func<PropertyInfo, IEnumerable<IEPiPropertyGetter>> getFunction)
        {
            var key = GetKey(property);
            var result = _cache.Get(key) as IEnumerable<IEPiPropertyGetter>;

            if (result == null)
            {
                result = getFunction(property) ?? Enumerable.Empty<IEPiPropertyGetter>();
                _cache.Add(key, result, new CacheItemPolicy());
            }

            return result;
        }

        public virtual bool Contains(PropertyInfo property)
        {
            var key = GetKey(property);
            var value = _cache.Get(key) as IEnumerable<IEPiPropertyGetter>;
            return value != null /*&& value.Any()*/;
        }
    }
}