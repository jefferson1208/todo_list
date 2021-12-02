using todo_list.api.Validations;
using todo_list.tests.Fixtures;
using Xunit;

namespace todo_list.tests.Unity
{
    [Collection(nameof(TodoCollection))]
    public class TodoValidationsTests 
    {
        private readonly TodoTestsFixture _todoTestsFixture;
        public TodoValidationsTests(TodoTestsFixture todoTestsFixture)
        {
            _todoTestsFixture = todoTestsFixture;
        }

        [Fact(DisplayName = "Should validate the todo entity")]
        [Trait(name: "Unity", value: "Todo")]
        public void Todos_ShouldValidateTodoEntity()
        {
            //ARRANGE
            var todos = _todoTestsFixture.GenerateListOfValidTodos(100);

            //ACT
            foreach (var todo in todos)
            {
                var validator = new TodoValidations(true).Validate(todo);


                //ASSERT

                Assert.True(validator.IsValid);
            }
        }

        [Fact(DisplayName = "Should invalidate the todo entity")]
        [Trait(name: "Unity", value: "Todo")]
        public void Todos_ShouldInvalidateTodoEntity()
        {
            //ARRANGE
            var todos = _todoTestsFixture.GenerateListOfInvalidTodos(100);

            //ACT
            foreach (var todo in todos)
            {
                var validator = new TodoValidations(true).Validate(todo);

                //ASSERT

                Assert.False(validator.IsValid);
            }
        }
    }
}
