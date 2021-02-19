using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain;

namespace TodoApp.Application.Todos.Commands
{
    public class CompleteTodoCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<CompleteTodoCommand>
        {
            private readonly DbContext context;

            public Handler(DbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(CompleteTodoCommand request, CancellationToken cancellationToken)
            {
                var todo = await context.Set<Todo>().FindAsync(request.Id);

                if (todo != null)
                {
                    todo.Complete();

                    await context.SaveChangesAsync(cancellationToken);
                }

                return Unit.Value;
            }
        }
    }
}
