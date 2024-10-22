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
        private Mock<IVideoRepository> _Repository;

        [SetUp]
       public void SetUp()
        {
            _FileReader = new Mock<IFileReader>();
            _Repository = new Mock<IVideoRepository>();
            _service = new VideoService(_FileReader.Object, _Repository.Object);
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
        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyList()
        {
            //Arrang
            var Video = _Repository.Setup(x => x.GetUnprocessedVideos()).Returns(new List<Video>());
            //Act 
            var result = _service.GetUnprocessedVideosAsCsv();

            // Assert
            Assert.That(result, Is.EqualTo(""));
        }
        [Test]
        public void GetUnprocessedVideosAsCsv_AfewVideosUnprocessedVideos_ReturnListOFIDS()
        {
            //Arrang
            var Video = _Repository.Setup(x => x.GetUnprocessedVideos()).Returns(new List<Video>{
                new Video { Id = 1},
                new Video { Id = 2 },
                new Video {Id = 3},
                new Video {Id = 4},
                new Video {Id = 5}
            });
            //Act 
            var result = _service.GetUnprocessedVideosAsCsv();


            // Assert
            Assert.That(result, Is.EqualTo("1,2,3,4,5"));
        }
    }
}
