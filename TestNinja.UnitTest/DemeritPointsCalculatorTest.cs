using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    public class DemeritPointsCalculatorTest
    {
        private DemeritPointsCalculator _demeritPointsCalculator;
        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }
        [Test]
        [TestCase(-5)]
        [TestCase(305)]
        public void CalculateDemeritPoints_ISTheSpeedOutOfRand_ReturnArgumentOutOfRangeException(int Speed)
        {
            //Assert
           Assert.That(() =>_demeritPointsCalculator.CalculateDemeritPoints(Speed),Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        [TestCase(65, 0)]
        [TestCase(60, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_ISTheSpeedEqualSpeedLimitOrLess_ReturnZero(int Speed,int ExpectedResult)
        {
            //Act
            var result = _demeritPointsCalculator.CalculateDemeritPoints(Speed);

            //Assert
            Assert.That(result,Is.EqualTo(ExpectedResult));
        }
    }
}
