namespace todo_list.api.Models
{
    public class Todo : Entity
    {
        public Todo(string title, bool done)
        {
            Title = title;
            Done = done;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }

        public void ChangeTittle(string title)
        {
            Title = title;
        }

        public void ChangeActivityStatus(bool status)
        {
            Done = status;
        }

        protected Todo() { }
    }
}
