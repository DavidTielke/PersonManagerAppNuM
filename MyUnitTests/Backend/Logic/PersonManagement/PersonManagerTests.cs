using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Data.DatabaseStorage;
using Backend.Logic.PersonManagement;
using ConsoleClient.CrossCutting;
using CrossCutting.DomainModel;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace MyUnitTests.Backend.Logic.PersonManagement
{
    [TestFixture]
    public class PersonManagerTests
    {
        private PersonManager _sut;
        private Mock<IPersonRepository> _repoMock;
        private Mock<IConfigurator> _configMock;
        private IPersonAddLogicValidator _validator;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IPersonRepository>();
            _configMock = new Mock<IConfigurator>();
            _configMock.Setup(m => m.Get<int>(It.IsAny<string>(), It.IsAny<int>())).Returns(18);
            _validator = new PersonAddLogicValidator();
            _sut = new PersonManager(_repoMock.Object, _configMock.Object, _validator);
        }

        [Test]
        public void GetAll_NoItemsFromRepo_EmptyCollection()
        {
            var result = _sut.GetAll();

            result.Should().HaveCount(0);
        }

        [Test]
        public void GetAll_TwoItemsFromRepo_TwoPersonsReturned()
        {
            _repoMock.Setup(m => m.GetAllPersons()).Returns(new List<Person>
            {
                new(1, "Test1", 18),
                new(2, "Test2", 17),
            }.AsQueryable());

            var result = _sut.GetAll();

            result.Should().HaveCount(2);
        }

        [Test]
        public void GetAllAdults_OneAdultFromRepo_OnePersonsReturned()
        {
            _repoMock.Setup(m => m.GetAllPersons()).Returns(new List<Person>
            {
                new(1, "Test1", 18),
                new(2, "Test2", 17),
            }.AsQueryable());

            var result = _sut.GetAllAdults();

            result.Should().HaveCount(1);
        }

        [Test]
        public void GetAllChildren_OneChildFromRepo_OnePersonsReturned()
        {
            _repoMock.Setup(m => m.GetAllPersons()).Returns(new List<Person>
            {
                new(1, "Test1", 18),
                new(2, "Test2", 17),
            }.AsQueryable());

            var result = _sut.GetAllChildren();

            result.Should().HaveCount(1);
        }
    }
}
