using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using TodoApp.Application.Todos.Commands;
using TodoApp.Application.Todos.Queries;

namespace TodoApp.Backend.Services
{
    public class TodoService : TodoApp.TodoActions.TodoActionsBase
    {
        private readonly IMediator _mediator;

        public TodoService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<TodoItem> Create(NewTodoRequest request, ServerCallContext context)
        {
            var command = new CreateTodoCommand
            {
                Title = request.Title,
                Description = request.Description,
                EndDate = DateTime.TryParse(request.EndDate, out var endDate) ? endDate : (DateTime?)null
            };

            var id = await _mediator.Send(command);

            return new TodoItem
            {
                Id = id
            };
        }

        public override async Task<TodoItemList> GetUncomplete(GetUncompleteTodosRequest request, ServerCallContext context)
        {
            var items = await _mediator.Send(new GetUncompletedTodosQuery());
            var response = new TodoItemList();

            foreach (var todoItem in items)
            {
                response.Items.Add(new TodoItem
                {
                    Title = todoItem.Title,
                    Id = todoItem.Id,
                    Description = todoItem.Description,
                    EndDate = todoItem.EndDate?.ToString("yyyy-MM-dd") ?? string.Empty
                });
            }

            return response;
        }

        public override async Task<Response> Complete(CompleteTodoRequest request, ServerCallContext context)
        {
            await _mediator.Send(new CompleteTodoCommand { Id = request.Id });

            return new Response { Success = true };
        }
    }
}
