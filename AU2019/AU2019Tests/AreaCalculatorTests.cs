using AU2019;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2019Tests
{
    [TestFixture]
    public class AreaCalculatorTests
    {
        private AreaCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new AreaCalculator();
        }
        [Test]
        public void Instantiate()
        {
            Assert.IsNotNull(_sut);
        }

        [Test]
        public void Sums_Area_Of_IAreaObjects()
        {
            var expected = 10;
            var testObjects = CreateObjectsToTest();
            _sut.Update(testObjects);

            var actual = _sut.Area;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Sums_Perimeter_Of_IAreaObjects()
        {
            var expected = 4;
            var testObjects = CreateObjectsToTest();
            _sut.Update(testObjects);

            var actual = _sut.Perimeter;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Counts_IAreaObjects()
        {
            var expected = 4;
            var testObjects = CreateObjectsToTest();
            _sut.Update(testObjects);

            var actual = _sut.Perimeter;

            Assert.That(actual, Is.EqualTo(expected));
        }

        private IEnumerable<IAreaObject> CreateObjectsToTest()
        {
            Mock<IAreaObject> mockArea1 = new Mock<IAreaObject>();
            mockArea1.Setup(x => x.Area).Returns(5);
            mockArea1.Setup(x => x.Perimeter).Returns(2);
            Mock<IAreaObject> mockArea2 = new Mock<IAreaObject>();
            mockArea2.Setup(x => x.Area).Returns(5);
            mockArea2.Setup(x => x.Perimeter).Returns(2);
            IEnumerable<IAreaObject> objects = new List<IAreaObject> { mockArea1.Object, mockArea2.Object };

            return objects;
        }
    }
}
