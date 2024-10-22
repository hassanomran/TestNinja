using Castle.Core.Smtp;
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
    public class HouseKeeperServiceTest
    {
        private Housekeeper _HouseKeeper;
        private Mock<IStatementGenerator> _IStatementGenerator;
        private Mock<IUnitOfWork> _IUnitOfWork;
        private Mock<TestNinja.Mocking.IEmailSender> _IEmailSender;
        private Mock<IXtraMessageBox> _IXtraMessageBox;
        private HouseKeeperService _HouseKeeperService;
        private readonly string _FileName = "FileName";

        [SetUp]
        public void SetUp()
        {
            _HouseKeeper = new Housekeeper
            {
                Oid = 1,
                Email = "billie.eilish@gmail.com",
                FullName = "billie eilish",
                StatementEmailBody = "Hello billie this October Statment Please Review It"
            };
            _IStatementGenerator = new Mock<IStatementGenerator>();
            _IUnitOfWork = new Mock<IUnitOfWork>();
            _IUnitOfWork.Setup(x => x.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                   _HouseKeeper
            }.AsQueryable());
            _IEmailSender = new Mock<TestNinja.Mocking.IEmailSender>();
            _IXtraMessageBox = new Mock<IXtraMessageBox>();
            _HouseKeeperService = new HouseKeeperService(
                _IUnitOfWork.Object, 
                _IStatementGenerator.Object,
                _IEmailSender.Object, 
                _IXtraMessageBox.Object)
                ;
        }
        [Test]
        [TestCase("2024-10-21")]
        public void SendStatementEmails_WhenCalled_GenerateStatementFile(DateTime statementDate)
        {
            //Arrang

            //Act
            
            _HouseKeeperService.SendStatementEmails(statementDate);
            //_IStatementGenerator.Setup(x => x.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()));
            _IStatementGenerator.Verify(x => x.
            SaveStatement(_HouseKeeper.Oid, _HouseKeeper.FullName,
            statementDate)
            );

        }
       
        [Test]
        [TestCase("2024-10-21"," ")]
        [TestCase("2024-10-21",null)]
        [TestCase("2024-10-21", "")]
        public void SendStatementEmails_EmailOfHouseKeeperIsWhiteSpaceAndNull_HouldNotGenerateStatementFile(DateTime statementDate,string Email)
        {
            //Arrang
            _HouseKeeper.Email = Email;
            //Act

            _HouseKeeperService.SendStatementEmails(statementDate);
            //_IStatementGenerator.Setup(x => x.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()));
            _IStatementGenerator.Verify(x => x.
            SaveStatement(_HouseKeeper.Oid, _HouseKeeper.FullName,
            statementDate)
            , Times.Never);

        }
        [Test]
        [TestCase("2024-10-21"," ")]
        [TestCase("2024-10-21",null)]
        [TestCase("2024-10-21", "")]
        public void SendStatementEmails_statementFilenameIsWhiteSpaceAndNull_HouldNotEmailStatementFile(DateTime statementDate,string statementFilename)
        {
            //Arrang
            //Act
            _IStatementGenerator
               .Setup(x => x.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()))
               .Returns(statementFilename);
            _HouseKeeperService.SendStatementEmails(statementDate);

            _IStatementGenerator.Verify(x => x.
            SaveStatement(_HouseKeeper.Oid, _HouseKeeper.FullName,
            statementDate)
            );
            _IEmailSender
                .Verify(x =>
                x.EmailFile(
                    _HouseKeeper.Email,
                    _HouseKeeper.StatementEmailBody,
                    _FileName,
                   It.IsAny<string>()
                    ),Times.Never);

        }

        [TestCase("2024-10-21")]
        [Test]
         public void SendStatementEmails_EmailAndstatmentareNotnull_SendEmailToHouseKeeper(DateTime statementDate)
        {
            //Arrang
            //Act
             _IStatementGenerator
                .Setup(x => x.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(_FileName);
            _HouseKeeperService.SendStatementEmails(statementDate);
           
            _IStatementGenerator.Verify(x => x.
            SaveStatement(_HouseKeeper.Oid, _HouseKeeper.FullName,
            statementDate)
            );
            _IEmailSender
                .Verify(x =>
                x.EmailFile(
                    _HouseKeeper.Email,
                    _HouseKeeper.StatementEmailBody, 
                    _FileName, 
                   It.IsAny<string>()
                    ));
        }


        [Test]
        public void SendStatementEmails_EmailAilse_SendMessageBox()
        {
            //Arrang
            //Act
            _IEmailSender.Setup(x => x.EmailFile(
                It.IsAny<string>(),
                 It.IsAny<string>(),
                  It.IsAny<string>(),
                   It.IsAny<string>()
                )).Throws<Exception>();
            _IXtraMessageBox.Setup(x => x.Show(
                It.IsAny<string>(),
                It.IsAny<string>(),
                MessageBoxButtons.OK
                ));
        }


    }
}
