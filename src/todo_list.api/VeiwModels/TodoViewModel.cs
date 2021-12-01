using System;

namespace todo_list.api.VeiwModels
{
    public class TodoViewModel
    {
        public string Title { get; set; }
        public bool Done { get; set; }
    }

    public class TodoBaseViewModel : TodoViewModel
    {
        public Guid Id { get; set; }
    }
}
