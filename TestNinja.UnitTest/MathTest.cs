using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class MathTest
    {
        private Fundamentals.Math _MAth;
        [SetUp]
        public void SetUp()
        {
            _MAth = new Fundamentals.Math();
        }
        [Test]
        [Ignore("because i didn't modify it")]
        public void Add_WhenCalled_ReturnTheSumOfnumber() 
        {
            // Arrang

            // Act
            var resutl = _MAth.Add(1, 3);

            // Assert

            Assert.That(resutl, Is.EqualTo(4));

        }

        [Test]
        [TestCase(20,6,20)]
        [TestCase(8, 50, 50)]
        [TestCase(6, 6, 6)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a,int b,int Expected)
        {
            // Arrang

            // Act
            var resutl = _MAth.Max(a, b);

            // Assert

            Assert.That(resutl, Is.EqualTo(Expected));

        }
        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnTheoodNumbers()
        {
            // arrang

            //Act
            var result = _MAth.GetOddNumbers(5);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(),Is.EqualTo(3));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
        }


    }
}
