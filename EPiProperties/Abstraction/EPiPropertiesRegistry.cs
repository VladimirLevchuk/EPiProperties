using System;
using System.Collections.Generic;
using System.Reflection;

namespace EPiProperties.Abstraction
{
    public class EPiPropertiesRegistry
    {
        private readonly Dictionary<Type, IEPiPropertyGetter> _getters = new Dictionary<Type, IEPiPropertyGetter>();
        private readonly Dictionary<Type, IEPiPropertySetter> _setters = new Dictionary<Type, IEPiPropertySetter>();

        private readonly List<Type> _getterAttributes = new List<Type>();
        private readonly List<Type> _setterAttributes = new List<Type>();

        private void AddGetter(Type annotationAttributeType, IEPiPropertyGetter getter)
        {
            _getters.Add(annotationAttributeType, getter);
            if (!_getterAttributes.Contains(annotationAttributeType))
            {
                _getterAttributes.Add(annotationAttributeType);
            }
        }

        private void AddSetter(Type annotationAttributeType, IEPiPropertySetter setter)
        {
            _setters.Add(annotationAttributeType, setter);
            if (!_setterAttributes.Contains(annotationAttributeType))
            {
                _setterAttributes.Add(annotationAttributeType);
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

            public void Use(IEPiPropertySetter setter)
            {
                _owner.AddSetter(_annotationAttributeType, setter);
            }

            public void Use(IEPiPropertyHandler handler)
            {
                _owner.AddGetter(_annotationAttributeType, handler);
                _owner.AddSetter(_annotationAttributeType, handler);
            }
        }

        public ForClause For<TAttribute>()
            where TAttribute: Attribute
        {
            return new ForClause(typeof(TAttribute), this);
        }

        public virtual IEPiPropertyGetter LookupGetter(PropertyInfo property)
        {
            throw new NotImplementedException();
            // var _attributes = property.GetCustomAttributes();
        }

        public virtual IEPiPropertySetter LookupSetter(PropertyInfo property)
        {
            throw new NotImplementedException();
        }
    }
}