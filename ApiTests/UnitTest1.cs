using System.Net.Http.Json;
using CrossCutting.DomainModel;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ServiceClient;

namespace ApiTests
{
    public class PersonApiTests
    {
        private WebApplicationFactory<Program> _server;
        private HttpClient _client;

        public PersonApiTests()
        {
            _server = new WebApplicationFactory<Program>();
        }

        [SetUp]
        public void Setup()
        {
            _client = _server.CreateClient();
        }

        [Test]
        public async Task Get_5PersonsInStore_5PersonsReturned()
        {
            var persons = await _client.GetFromJsonAsync<IEnumerable<Person>>("/Persons");

            persons.Should().HaveCount(5);
        }

        [Test]
        public async Task Get_5PersonsInStore_2AdultsReturned()
        {
            var persons = await _client.GetFromJsonAsync<IEnumerable<Person>>("/Persons/Adults");

            persons.Should().HaveCount(2);
        }

        [Test]
        public async Task Get_5PersonsInStore_2ChildsReturned()
        {
            var persons = await _client.GetFromJsonAsync<IEnumerable<Person>>("/Persons/Children");

            persons.Should().HaveCount(3);
        }
    }
}