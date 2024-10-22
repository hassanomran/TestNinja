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
        private Mock<IFileReader> _FileReader;
        private Mock<IVideoRepository> _Repository;
        private VideoService _service;

        [SetUp]
        public void SetUp()
        {
            _FileReader = new Mock<IFileReader>();
            _Repository = new Mock<IVideoRepository>();
            _service = new VideoService(_FileReader.Object, _Repository.Object);
        }

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

