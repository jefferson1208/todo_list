using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using todo_list.api.Data.Interfaces;
using todo_list.api.Models;

namespace todo_list.api.Data.Context
{
    public class TodoContext : IUnitOfWork
    {
        private readonly string _jsonFile;
        public TodoContext()
        {
            _jsonFile = $@"{AppDomain.CurrentDomain.BaseDirectory}Data\TodoList.json";

            using (StreamReader file = new StreamReader(_jsonFile))
            {
                string json = file.ReadToEnd();
                TodoList = JsonConvert.DeserializeObject<List<Todo>>(json);
            }
        }

        public List<Todo> TodoList { get; set; }
        public async Task<bool> Commit()
        {
            var jsonTodoList = JsonConvert.SerializeObject(TodoList);

            using (StreamWriter write = new StreamWriter(_jsonFile))
            {
                write.WriteLine(jsonTodoList);
            };

            return await Task.FromResult(true);
        }
    }
}
