using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using todo_list.api;
using todo_list.tests.Fixtures;
using Xunit;

namespace todo_list.tests.Integration.Controllers
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class TodoControllerTests
    {
        private readonly IntegrationTestsFixture<StartupTests> _integrationTestsFixture;
        public TodoControllerTests(IntegrationTestsFixture<StartupTests> integrationTestsFixture)
        {
            _integrationTestsFixture = integrationTestsFixture;
        }

        [Fact(DisplayName = "Should create a task")]
        [Trait(name: "Integration", value: "")]
        public async Task CreateTodo_ShouldCreateTaskSucessfully()
        {
            //ARRANGE
            var todo = _integrationTestsFixture.CreateTodoViewModel();

            //ACT
            var result = await _integrationTestsFixture._client.PostAsJsonAsync("api/v1/todo/create", todo);

            //ASSERT
            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}
