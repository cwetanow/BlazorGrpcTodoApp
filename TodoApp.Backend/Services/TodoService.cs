using System;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using TodoApp.Application.Todos.Commands;

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
    }
}
