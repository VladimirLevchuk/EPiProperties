using System;
using System.Collections.Generic;
using EPiProperties.Util;
using NUnit.Framework;
using FluentAssertions;

namespace EPiProperties.Tests.Util
{
    public class TypeExtensionsTests
    {
        [Test]
        public void Is_Acceptance()
        {
            // I know it looks a bit ugly... but at least it shows the intended usage :)

            var testee = new GenericChild<string>().GetType();

            testee.Is<IInterface>().Should().BeTrue();

            testee.Is<Parent>().Should().BeTrue();

            testee.Is<Child>().Should().BeTrue();

            testee.Is<IList<string>>().Should().BeTrue();

            testee.Is<ITypedInterface<Parent>>().Should().BeTrue();

            testee.IsOpenGeneric(typeof(ITypedInterface<>)).Should().BeTrue();

            testee.IsOpenGeneric(typeof(IList<>)).Should().BeTrue();

            testee.TryGetCollectionItemType().Should().Be(typeof(string));
        }
    }

    interface IInterface
    {
        object Value { get; }
    }

    interface ITypedInterface<out T> : IInterface
    {
        T Value { get; }
    }

    class Parent
    {}

    class Child : Parent, IInterface
    {
        #region IInterface Members

        object IInterface.Value
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }

    class GenericChild<T> : Child, IList<T>, ITypedInterface<Parent>
    {
        #region IList<T> Members

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICollection<T> Members

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        object IInterface.Value
        {
            get { throw new NotImplementedException(); }
        }

        #region ITypedInterface<Parent> Members

        Parent ITypedInterface<Parent>.Value
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
