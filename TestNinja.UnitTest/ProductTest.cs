using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void GetPrice_GoldCustomer_Apply70Discount()
        {
            // Arrang 
            var product = new Product{ ListPrice = 100 };

            // ACt 
            var Price = product.GetPrice(new Customer { IsGold = true });

            // Assert
            Assert.That(Price, Is.EqualTo(70));
        }
    }
}
