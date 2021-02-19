using System;
using TodoApp.Domain.Common;

namespace TodoApp.Domain
{
    public class Todo : Entity
    {
        private Todo()
        { }

        public Todo(string title, string description, DateTime? endDate)
        {
            Title = title;
            Description = description;
            EndDate = endDate;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? EndDate { get; private set; }

        public bool IsCompleted { get; private set; } = false;

        public void Complete()
        {
            this.IsCompleted = true;
        }
    }
}
