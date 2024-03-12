using ConsoleClient.Data;

namespace UnitTests.Mocks
{
    public class PersonRepoMock : IPersonRepository
    {
        public List<Person> Persons { get; set; } = new List<Person>();
        public List<Person> GetAllPersons()
        {
            return Persons;
        }
    }
}