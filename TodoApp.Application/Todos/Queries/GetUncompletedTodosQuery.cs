using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Todos.Models;
using TodoApp.Domain;

namespace TodoApp.Application.Todos.Queries
{
    public class GetUncompletedTodosQuery : IRequest<IEnumerable<TodoItem>>
    {
        public class Handler : IRequestHandler<GetUncompletedTodosQuery, IEnumerable<TodoItem>>
        {
            private readonly DbContext context;

            public Handler(DbContext context)
            {
                this.context = context;
            }

            public async Task<IEnumerable<TodoItem>> Handle(GetUncompletedTodosQuery request, CancellationToken cancellationToken) =>
                await context.Set<Todo>()
                    .Where(t => !t.IsCompleted)
                    .Select(t => new TodoItem
                    {
                        Id = t.Id,
                        Description = t.Description,
                        Title = t.Title,
                        EndDate = t.EndDate
                    })
                    .ToListAsync(cancellationToken);
        }
    }
}
