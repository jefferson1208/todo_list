using Bogus;
using System.Collections.Generic;
using todo_list.api.Models;
using Xunit;

namespace todo_list.tests.Fixtures
{
    [CollectionDefinition(nameof(TodoCollection))]
    public class TodoCollection : ICollectionFixture<TodoTestsFixture> { }
    public class TodoTestsFixture
    {
        public List<Todo> GenerateListOfValidTodos(int quantity = 1)
        {
            var todos = new Faker<Todo>("pt_BR")
                .CustomInstantiator(p => new Todo(p.Random.String(20), false));

            return todos.Generate(quantity);
        }

        public List<Todo> GenerateListOfInvalidTodos(int quantity = 1)
        {
            var todos = new Faker<Todo>("pt_BR")
                .CustomInstantiator(p => new Todo(p.Random.String(8), false));

            return todos.Generate(quantity);
        }
    }
}
