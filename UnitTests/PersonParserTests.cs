using ConsoleClient.Data;

namespace UnitTests
{
    [TestFixture]
    public class PersonParserTests
    {
        private PersonParser _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PersonParser();
        }


        [Test]
        public void ParseFromCSV_LinesAreNull_ArgumentNullException()
        {
            string[] lines = null;

            Assert.Throws<ArgumentNullException>(() => _sut.ParseFromCSV(null));
        }

        [Test]
        public void ParseFromCSV_OneValidInputLine_OnePersonReturned()
        {
            string[] lines = new []{"1,Test1,23"};
            var expectedCount = 1;

            var actual = _sut.ParseFromCSV(lines).Count;

            Assert.AreEqual(expectedCount, actual);
        }
        
        [Test]
        public void ParseFromCSV_OneValidInputLine_CorrectPersonReturned()
        {
            var lines = new[] { "1,Test1,23" };

            var actual = _sut.ParseFromCSV(lines).First();

            Assert.AreEqual(1, actual.Id);
            Assert.AreEqual("Test1", actual.Name);
            Assert.AreEqual(23, actual.Age);
        }

        [Test]
        public void ParseFromCSV_TwoValidInputLine_TwoPersonReturned() { }
        [Test]
        public void ParseFromCSV_TwoValidInputLine_CorrectOrderReturned() { }
    }
}
