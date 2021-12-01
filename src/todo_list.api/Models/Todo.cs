using System;

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

        protected Todo() { }
    }
}
