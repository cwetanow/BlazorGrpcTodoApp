using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain;

namespace TodoApp.Application.Todos.Commands
{
    public class CreateTodoCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }

        public class Handler : IRequestHandler<CreateTodoCommand, int>
        {
            private readonly DbContext context;

            public Handler(DbContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
            {
                var todo = new Todo(request.Title, request.Description, request.EndDate);

                context.Add(todo);
                await context.SaveChangesAsync(cancellationToken);

                return todo.Id;
            }
        }
    }
}
