using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class OrderServiceTest
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreOrder()
        {
            //Arrang
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);

            //Act
            var order = new Order();
            service.PlaceOrder(order);

            // Assert
            storage.Verify(x => x.Store(order));
        }
    }
}
