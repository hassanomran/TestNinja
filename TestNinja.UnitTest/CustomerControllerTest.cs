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
    public class CustomerControllerTest
    {
        [Test]
        public void GetCustomer_WhenCustmerISZero_ReturnNotFound()
        {
            // Arrange
            var customercontroller = new CustomerController();

            // Act
            var result = customercontroller.GetCustomer(0);

            //Assert
            // NotFound Objects
            Assert.That(result, Is.TypeOf<NotFound>());
            // NotFound Objects and it's derivative

            Assert.That(result, Is.InstanceOf<NotFound>());

        }
        [Test]
        public void GetCustomer_WhenCustmerISNotZero_ReturnOK()
        {
            // Arrange
            var customercontroller = new CustomerController();

            // Act
            var result = customercontroller.GetCustomer(2);

            //Assert
            // Ok Objects
            Assert.That(result, Is.TypeOf<Ok>());

            // Ok Objects and it's derivative
            Assert.That(result, Is.InstanceOf<Ok>());
        }
    }
}
