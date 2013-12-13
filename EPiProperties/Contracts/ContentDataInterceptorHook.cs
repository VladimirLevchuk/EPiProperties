using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace EPiProperties.Contracts
{
    public abstract class ContentDataInterceptorHook : IProxyGenerationHook
    {
        public virtual void MethodsInspected()
        {}

        public virtual void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {}

        public abstract bool ShouldInterceptMethod(Type type, MethodInfo methodInfo);

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;
            if (obj != null)
                return obj.GetType() == GetType();
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }
    }
}