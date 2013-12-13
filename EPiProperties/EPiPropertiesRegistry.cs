using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using EPiProperties.Contracts;
using EPiServer.ServiceLocation;

namespace EPiProperties
{
    public class EPiPropertiesRegistry : IEPiPropertiesRegistry
    {
        public EPiPropertiesRegistry(PropertyGetterCache cache)
        {
            _cache = cache;
        }

        private readonly PropertyGetterCache _cache;
        private readonly Dictionary<Type, Type> _getters = new Dictionary<Type, Type>();

        private readonly List<Type> _getterAttributes = new List<Type>();

        protected virtual List<Type> GetterAttributes { get { return _getterAttributes; }}

        private void AddGetter(Type annotationAttributeType, Type getter)
        {
            _getters.Add(annotationAttributeType, getter);
            if (!_getterAttributes.Contains(annotationAttributeType))
            {
                _getterAttributes.Add(annotationAttributeType);
            }
        }

        public class ForClause
        {
            private readonly EPiPropertiesRegistry _owner;
            private readonly Type _annotationAttributeType;

            public ForClause(Type annotationAttributeType, EPiPropertiesRegistry owner)
            {
                _owner = owner;
                _annotationAttributeType = annotationAttributeType;
            }

            public void Use<TPropertyGetter>()
                where TPropertyGetter: IEPiPropertyGetter
            {
                _owner.AddGetter(_annotationAttributeType, typeof(TPropertyGetter));
            }
        }

        public ForClause For<TAttribute>()
            where TAttribute: Attribute
        {
            return new ForClause(typeof(TAttribute), this);
        }

        protected IEnumerable<IEPiPropertyGetter> LookupGettersImplementation(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(true);

            var annotationAttributeType = attributes.Select(x => x.GetType()).Intersect(GetterAttributes).FirstOrDefault();

            if (annotationAttributeType != null && _getters.ContainsKey(annotationAttributeType))
            {
                return new[] { (IEPiPropertyGetter)ServiceLocator.Current.GetService(_getters[annotationAttributeType]) };
            }

            return Enumerable.Empty<IEPiPropertyGetter>();            
        }

        public virtual IEnumerable<IEPiPropertyGetter> LookupGetters(PropertyInfo property)
        {
            // more correct way is to cache just getter types and create them using IoC on every call. 
            // but suppose performance is more important than getter lifetimes. 
            // so they have to be stateless and thread safe. 
            return _cache.AddOrGet(property, LookupGettersImplementation);
        }

        public virtual bool IsEPiProperty(PropertyInfo property)
        {
            return LookupGetters(property).Any();
        }
    }
}