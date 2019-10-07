using AU2019;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019Tests
{
    [TestFixture]
    public class CircleFilterTests : IFilterSourceTestsBase<CircleFilter>
    {
        [Test]
        public override void GetFilter_Returns_ArrayOfTypedValue()
        {
            GetFilter_Returns_ArrayOfTypedValue(1);
        }
    }

    //[TestFixture]
    //public class CircleFilterTests
    //{
    //    CircleFilter sut;
    //    [SetUp]
    //    public void Setup()
    //    {
    //        sut = new CircleFilter();
    //    }
    //    [Test]
    //    public void Instantiate()
    //    {
    //        Assert.IsNotNull(sut);
    //    }

    //[Test]
    //public void GetFilter_Returns_ArrayOfTypedValue()
    //{
    //    //Arrange
    //    var expected = 1;

    //    //Act
    //    var actual = sut.GetFilter();
    //    //Assert
    //    Assert.That(actual.Length, Is.EqualTo(expected));
    //}
    //}
}
