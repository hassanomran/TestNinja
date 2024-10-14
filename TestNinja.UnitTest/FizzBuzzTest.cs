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
    public class FizzBuzzTest
    {
        private FizzBuzz _fizzBuzz;
        [SetUp]
        public void SetUp()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Test]
        public void GetOutput_IsTheNumberdivisiblebyboth3and5_ReturnFizzBuzz()
        {
            // Arrange

            //Act 
            var result = _fizzBuzz.GetOutput(15);

            // Assert

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }
        [Test]
        public void GetOutput_IsTheNumberdivisibleby3_ReturnFizz()
        {
            // Arrange

            //Act 
            var result = _fizzBuzz.GetOutput(9);

            // Assert

            Assert.That(result, Is.EqualTo("Fizz"));
        }
        [Test]
        public void GetOutput_IsTheNumberdivisibleby5_ReturnBuzz()
        {
            // Arrange

            //Act 
            var result = _fizzBuzz.GetOutput(10);

            // Assert

            Assert.That(result, Is.EqualTo("Buzz"));
        }
        [Test]
        public void GetOutput_IsTheNumberCanNotdivisiblebyboth3and5_ReturnStringNumber()
        {
            // Arrange

            //Act 
            var result = _fizzBuzz.GetOutput(4);

            // Assert

            Assert.That(result, Is.EqualTo("4"));
        }


    }
}
