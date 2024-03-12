namespace UnitTests2
{
    [TestFixture]
    public class DreieckTypCheckerTests
    {
        private DreieckTypChecker _sut;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {

        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {

        }

        [SetUp]
        public void SetUp()
        {
            _sut = new DreieckTypChecker();
        }

        [TearDown]
        public void TearDown()
        {
            _sut = null;
        }

        [Test]
        [Category("GetTyp")]
        public void GetTyp_Gleichseitig()
        {
            var a = 1;
            var b = 1;
            var c = 1;
            var expected = DreieckTyp.Gleichseitig;

            var actual = _sut.GetTyp(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("GetTyp")]
        public void GetTyp_Min()
        {
            var a = int.MinValue;
            var b = int.MinValue;
            var c = int.MinValue;

            Assert.Throws<ArgumentException>(() => _sut.GetTyp(a, b, c));
        }
        
        [Test]
        [Category("GetTyp")]
        // SUT_Precondidtion_PostCondition
        public void GetTyp_AllSidesMax_GleichseitigTriangle()
        {
            // Tripple-A-Pattern
            // Arrange
            var a = int.MaxValue;
            var b = int.MaxValue;
            var c = int.MaxValue;
            var expected = DreieckTyp.Gleichseitig;

            // Act
            var actual = _sut.GetTyp(a, b, c);
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, 5, 6)]
        [TestCase(4, 6, 5)]
        [TestCase(6, 5, 4)]
        [Category("GetTyp")]
        public void GetTyp_Normal(int a, int b, int c)
        {
            var expected = DreieckTyp.Normal;

            var actual = _sut.GetTyp(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 1)]
        [TestCase(2, 1, 2)]
        [Category("GetTyp")]
        public void GetTyp_Gleichschenklig(int a, int b, int c)
        {
            var expected = DreieckTyp.Gleichschenklig;

            var actual = _sut.GetTyp(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 0)]
        [Category("GetTyp")]
        public void GetTyp_SeiteNull(int a, int b, int c)
        {
            Assert.Throws<ArgumentException>(() => _sut.GetTyp(a, b, c));
        }


        [TestCase(-1, -1, -1)]
        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        [Category("GetTyp")]
        public void GetTyp_SeiteNegativ(int a, int b, int c)
        {
            Assert.Throws<ArgumentException>(() => _sut.GetTyp(a, b, c));
        }

        [TestCase(1, 2, 1)]
        [TestCase(1, 3, 1)]
        [Category("GetTyp")]
        public void GetTyp_NichtKonstruierbar(int a, int b, int c)
        {
            Assert.Throws<ArgumentException>(() => _sut.GetTyp(a, b, c));
        }
    }
}