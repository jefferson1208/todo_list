namespace todo_list.api.Models
{
    public class Todo : Entity
    {
        public Todo(string title, bool done)
        {
            Title = title;
            Done = done;
            Active = true;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public bool Active { get; private set; }
        public void ChangeTittle(string title)
        {
            Title = title;
        }

        public void ChangeActivityStatus(bool status)
        {
            Done = status;
        }

        public void DisableActivity()
        {
            Active = false;
        }
        protected Todo() { }
    }
}
