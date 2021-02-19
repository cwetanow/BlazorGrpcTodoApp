using System;

namespace TodoApp.Application.Todos.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
