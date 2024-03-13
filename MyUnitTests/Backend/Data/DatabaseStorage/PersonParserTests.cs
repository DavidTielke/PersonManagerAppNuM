using System.Collections.Immutable;
using Backend.Data.DatabaseStorage;

namespace MyUnitTests.Backend.Data.DatabaseStorage
{
    [TestFixture]
    public class PersonParserTests
    {
        [Test]
        public void ParseFromCsv_OneValidLine_OnePersonReturned()
        {
            var parser = new PersonParser();
            var lines = new[] { "1,Test,23" };

            var actual = parser.ParseFromCSV(lines);

            Assert.AreEqual(1, actual.Count);
        }

        [Test]
        public void ParseFromCsv_OneValidLine_CorrectPersonReturned()
        {
            var parser = new PersonParser();
            var lines = new[] { "1,Test,23" };

            var actual = parser.ParseFromCSV(lines).First();

            Assert.AreEqual(1, actual.Id);
            Assert.AreEqual("Test", actual.Name);
            Assert.AreEqual(23, actual.Age);
        }

        [Test]
        public void ParseFromCsv_TwoValidLines_TwoPersonReturned()
        {
            var parser = new PersonParser();
            var lines = new[] { "1,Test,23", "2,Test2,24" };

            var actual = parser.ParseFromCSV(lines);

            Assert.AreEqual(2, actual.Count);
        }

        [Test]
        public void ParseFromCsv_TwoValidLine_CorrectOrder()
        {
            var parser = new PersonParser();
            var lines = new[] { "1,Test,23", "2,Test2,24" };

            var actual = parser.ParseFromCSV(lines);

            Assert.AreEqual(1, actual.First().Id);
            Assert.AreEqual(2, actual.Last().Id);
        }


        [Test]
        public void ParseFromCsv_InvalidLine_FormatException()
        {
            var parser = new PersonParser();
            var lines = new[] { "1,Test23" };

            Assert.Throws<FormatException>(() => parser.ParseFromCSV(lines));
        }

        [Test]
        public void ParseFromCsv_LinesAreNull_ArgumentNullException()
        {
            var parser = new PersonParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseFromCSV(null));
        }
    }
}