using AU2019;
using NUnit.Framework;
using System;

namespace AU2019Tests
{
    public abstract class IFilterSourceTestsBase<T>
        where T : IFilterSource
    {
        protected T sut;

        [SetUp]
        public void Setup()
        {
            sut = Activator.CreateInstance<T>();
        }

        [Test]
        public virtual void Instantiate()
        {
            Assert.IsNotNull(sut);
        }

        protected void GetFilter_Returns_ArrayOfTypedValue(int expected)
        {
            var actual = sut.GetFilter();

            Assert.That(actual.Length, Is.EqualTo(expected));
        }

        public abstract void GetFilter_Returns_ArrayOfTypedValue();
    }
}
