using System;
using TodoApp.Domain.Common;

namespace TodoApp.Domain
{
    public class Todo : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
