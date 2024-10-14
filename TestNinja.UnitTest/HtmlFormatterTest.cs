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
    public class HtmlFormatterTest
    {
        [Test]
        public void FormatAsBold_WhenCalled_ReturnTheConententWithStrongFormatter()
        {
            // Arrang
            var Formatter = new HtmlFormatter();

            // Act
            var result = Formatter.FormatAsBold("ABC");

            // Assert
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("ABC"));
        }
    }
}
