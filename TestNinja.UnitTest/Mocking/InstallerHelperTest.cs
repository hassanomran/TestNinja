using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class InstallerHelperTest
    {
        private Mock<IDownloadFileRepository> _FileDownloader;
        private InstallerHelper _InstallerHelper;

        [SetUp]
        public void Setup()
        {
            _FileDownloader = new Mock<IDownloadFileRepository>();
            _InstallerHelper = new InstallerHelper(_FileDownloader.Object);
        }
        [Test]
        public void DownloadFile_DownloadFials_ReturnFalse()
        {
            //Assert
            _FileDownloader.
                Setup(x => x.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            //Act
            var result = _InstallerHelper.DownloadInstaller("Customer", "installer");

            //Assert
            Assert.That(result, Is.False);
        }
        [Test]
        public void DownloadFile_DownloadComplete_ReturnTrue()
        {
            //Assert
            //_FileDownloader.
            //    Setup(x => x.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
            //    .Throws<WebException>();

            //Act
            var result = _InstallerHelper.DownloadInstaller("Customer", "installer");

            //Assert
            Assert.That(result, Is.True);
        }
    }
}
