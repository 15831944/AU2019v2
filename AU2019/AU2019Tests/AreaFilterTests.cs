using AU2019;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019Tests
{
    [TestFixture]
    public class AreaFilterTests
    {
        AreaFilter sut;
        [SetUp]
        public void Setup()
        {
            sut = new AreaFilter();
        }

        [Test]
        public void Instantiate()
        {
            Assert.IsNotNull(sut);
        }

        [Test]
        public void GetFilter_Returns_ArrayOfTypedValue()
        {
            //Arrange
            var expected = 5;

            //Act
            var actual = sut.GetFilter();
            //Assert
            Assert.That(actual.Length, Is.EqualTo(expected));
        }
    }
    //[TestFixture]
    //public class AreaFilterTests : IFilterSourceTestsBase<AreaFilter>
    //{

    //    [Test]
    //    public override void GetFilter_Returns_ArrayOfTypedValue()
    //    {
    //        GetFilter_Returns_ArrayOfTypedValue(5);
    //    }

    //}
}
