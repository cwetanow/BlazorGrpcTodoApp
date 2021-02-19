using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace TodoApp.UI.Pages
{
    public partial class CreateTodo : ComponentBase
    {
        public NewTodoRequest Request { get; set; } = new NewTodoRequest { EndDate = DateTime.UtcNow.ToLongDateString() };

        [Inject]
        public TodoActions.TodoActionsClient Client { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        public async Task Create()
        {
            var response = await Client.CreateAsync(this.Request);
            this.Navigation.NavigateTo(string.Empty);
        }
    }
}
