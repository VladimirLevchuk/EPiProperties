using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using EPiServer.ServiceLocation;

namespace EPiProperties.Abstraction
{
    public class EPiPropertiesRegistry
    {
        private readonly Dictionary<Type, IEPiPropertyGetter> _getters = new Dictionary<Type, IEPiPropertyGetter>();

        private readonly List<Type> _getterAttributes = new List<Type>();

        protected virtual List<Type> GetterAttributes { get { return _getterAttributes; }}

        private void AddGetter(Type annotationAttributeType, IEPiPropertyGetter getter)
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

            public void Use(IEPiPropertyGetter getter)
            {
                _owner.AddGetter(_annotationAttributeType, getter);
            }

            public void Use<TPropertyGetter>()
                where TPropertyGetter: IEPiPropertyGetter
            {
                _owner.AddGetter(_annotationAttributeType, ServiceLocator.Current.GetInstance<TPropertyGetter>());
            }
        }

        public ForClause For<TAttribute>()
            where TAttribute: Attribute
        {
            return new ForClause(typeof(TAttribute), this);
        }

        public virtual IEPiPropertyGetter LookupGetter(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(true);

            var annotationAttributeType = attributes.Select(x => x.GetType()).Intersect(GetterAttributes).FirstOrDefault();

            if (annotationAttributeType != null && _getters.ContainsKey(annotationAttributeType))
            {
                return _getters[annotationAttributeType];
            }

            return null;
        }
    }
}