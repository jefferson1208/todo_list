using Bogus;
using System;
using System.Net.Http;
using todo_list.api;
using todo_list.api.Data.Context;
using todo_list.api.VeiwModels;
using todo_list.tests.Integration.Configuration;
using Xunit;

namespace todo_list.tests.Fixtures
{
    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupTests>> { }
    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public HttpClient _client;
        private readonly AppFactory<TStartup> _factory;
        private readonly TodoContext _todoContext;
        public IntegrationTestsFixture()
        {
            _factory = new AppFactory<TStartup>();
            _client = _factory.CreateClient();
            
            //para conseguir pegar um id existente para atualização
            _todoContext = new TodoContext();
        }

        public TodoViewModel CreateTodoViewModel()
        {
            var faker = new Faker("pt_BR");

            return new TodoViewModel
            {
                Title = faker.Company.CompanyName(),
                Done = false
            };
        }

        public TodoBaseViewModel GenerateUpdateTodoViewModel()
        {
            var faker = new Faker("pt_BR");

            return new TodoBaseViewModel
            {
                Title = faker.Random.String(20),
                Done = true
            };
        }
        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
