using Moq;
using Newtonsoft.Json;
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
    public class VideoServiceTest
    {
        private Mock<IFileReader> _FileReader;
        private VideoService _service;

        [SetUp]
       public void SetUp()
        {
            _FileReader = new Mock<IFileReader>();
            _service    = new VideoService();
        }

        [Test]
        public void ReadVideoTitle_EmptyPathString_ReturnError()
        {
            // Arrang
            _FileReader.Setup(x => x.ReadFile("video.txt")).Returns("");

            //Act
            var result = _service.ReadVideoTitle(_FileReader.Object);

            //Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
        [Test]
        public void ReadVideoTitle_HaveVideoPathString_ReturnVideoTitle()
        {
            // Arrang
            var jsonString = "{\"title\": \"WayhaAamrDiab\"}";
            _FileReader.Setup(x => x.ReadFile("video.txt")).Returns(jsonString);

            //Act
            var result = _service.ReadVideoTitle(_FileReader.Object);

            //Assert
            Assert.That(result, Does.Contain("WayhaAamrDiab").IgnoreCase);
        }
    }
}
