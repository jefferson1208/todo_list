using AutoMapper;
using todo_list.api.Models;
using todo_list.api.VeiwModels;

namespace todo_list.api.Setup
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<TodoViewModel, Todo>()
            .ConstructUsing(t => new Todo(t.Title, t.Done));

            CreateMap<TodoBaseViewModel, Todo>()
            .ConstructUsing(t => new Todo(t.Title, t.Done));

            CreateMap<Todo, TodoViewModel>();
            CreateMap<Todo, TodoBaseViewModel>();
        }
    }
}
