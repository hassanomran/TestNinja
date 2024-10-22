using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class EmployeeTest
    {
        private Mock<IEmployeeRepository> _IEmployeeRepository;
        private EmployeeController _EmployeeController;

        [SetUp]
        public void SetUp()
        {
            _IEmployeeRepository = new Mock<IEmployeeRepository>();
            _EmployeeController = new EmployeeController(_IEmployeeRepository.Object);
        }
        //[Test]
        //public void DeleteEmployee_WhenCalled_RedirectToAction() 
        //{
        //    //Arrange
        //    _IEmployeeRepository.Setup(x => x.RemoveById(5)).Returns(true);
            
        //    // Act
        //    var result = _EmployeeController.DeleteEmployee(5);

        //    //Assert
        //    Assert.That(result.ro,Throws.)
        //}
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmploye()
        {
            //Arrange

            // Act
            var result = _EmployeeController.DeleteEmployee(5);

            //Assert
            _IEmployeeRepository.Verify(x =>x.RemoveById(5));
        }

    }
}
