using System.Threading.Tasks;
using Grpc.Core;

namespace TodoApp.Backend.Services
{
    public class TodoService : TodoApp.TodoActions.TodoActionsBase
    {
        public override Task<TodoItem> Create(NewTodoRequest request, ServerCallContext context)
        {
            var result = new TodoItem
            {
                Id = 5,
                Description = request.Description,
                EndDate = request.EndDate,
                Title = request.Title
            };

            return Task.FromResult(result);
        }
    }
}
