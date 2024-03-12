using ConsoleClient.Logic;

namespace UnitTests;

public class PersonManagerTests
{
    private PersonRepoMock _repoMock;
    private PersonManager _sut;
    private ConfigMock _configMock;

    [SetUp]
    public void SetUp()
    {
        _repoMock = new PersonRepoMock();
        _configMock = new ConfigMock();
        _sut = new PersonManager(_repoMock, _configMock);
    }

    [Test]
    [Category("GetAllAdults")]
    public void GetAllAdults_2Adults2ChildrenInRepo_2AdultsReturned()
    {
        var expected = 2;
        _repoMock.Persons.Add(new Person(1,"Test1",16));
        _repoMock.Persons.Add(new Person(2,"Test2",17));
        _repoMock.Persons.Add(new Person(3,"Test3",18));
        _repoMock.Persons.Add(new Person(4,"Test4",19));
        _configMock.AgeTreshold = 18;

        var actual = _sut.GetAllAdults().Count;

        Assert.AreEqual(expected, actual);
    }
}