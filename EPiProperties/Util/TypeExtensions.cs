using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EPiProperties.Util
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Checks if the given type is (assignable from) a base type. 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="baseType"></param>
        /// <returns></returns>
        public static bool Is(this Type type, Type baseType)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (baseType == null)
            {
                throw new ArgumentNullException("baseType");
            }
            return baseType.IsAssignableFrom(type);
        }

        public static bool Is<TBaseTypeOrInterface>(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return type.Is(typeof(TBaseTypeOrInterface));
        }

        public static bool IsOpenGeneric(this Type type, Type genericInterfaceType)
        {
            if (!genericInterfaceType.IsGenericTypeDefinition)
            {
                return type.Is(genericInterfaceType);
            }

            return InternalIsOpenGeneric(type, genericInterfaceType);
        }

        /// <summary>
        /// doesn't check that genericInterfaceType is really a generic type definition. 
        /// This check is doen once by a public API method. 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="genericInterfaceType"></param>
        /// <returns></returns>
        internal static bool InternalIsOpenGeneric(this Type type, Type genericInterfaceType)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == genericInterfaceType)
            {
                return true;
            }

            if (type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == genericInterfaceType))
            {
                return true;
            }

            return type.BaseType != null && InternalIsOpenGeneric(type.BaseType, genericInterfaceType);
        }

        public static bool IsExactly<T>(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return type == typeof(T);
        }

        /// <summary>
        /// Tries to get the item type of the given collection. 
        /// </summary>
        /// <param name="type">Type you think is collection. </param>
        /// <returns>Colleection item type if found, otherwise null. </returns>
        public static Type TryGetCollectionItemType(this Type type)
        {
            if (type == null)
            {
                return null;
            }

            if (type.IsArray)
            {
                return type.GetElementType();
            }

            if (!type.Is<IEnumerable>() || !type.IsGenericType || type.IsGenericTypeDefinition)
                return null;

            if (type.IsOpenGeneric(typeof(IList<>))
                    || type.IsOpenGeneric(typeof(ICollection<>))
                    || type.IsOpenGeneric(typeof(IEnumerable<>)))
            {
                return type.GetGenericArguments().FirstOrDefault();
            }

            return null;
        }
    }
}
