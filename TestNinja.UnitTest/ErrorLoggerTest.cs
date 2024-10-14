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
    public class ErrorLoggerTest
    {
        private ErrorLogger _ErrorLogger;
        [SetUp]
       public void SetUp()
        {
            _ErrorLogger = new ErrorLogger();
        }
        [Test]
        public void Log_WhenCalled_SettheLastErrorProperty()
        {
            // Arrang 
           // var LogObject = new ErrorLogger();

            // Act
            _ErrorLogger.Log("a");

            //Assert

            Assert.That(_ErrorLogger.LastError, Is.EqualTo("a")); 
        }
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Log_WhenErrorIsNullO_ReturnArgumentNullException(string error)
        {
            // Arrang 
            //var LogObject = new ErrorLogger();

            // Act

            //Assert

            Assert.That(()=> _ErrorLogger.Log(error),Throws.ArgumentNullException);
        }
        [Test]
        public void Log_ValidError_RaiseErrorArgument()
        {
            // Arrang 
            //var LogObject = new ErrorLogger();

            // Act
            var id = Guid.Empty;
            _ErrorLogger.ErrorLogged += (sender,args) =>{ id = args; };
            _ErrorLogger.Log("a");

            //Assert
            Assert.That(id,Is.Not.EqualTo(Guid.Empty));
        }
    }
}
