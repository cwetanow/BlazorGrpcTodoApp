using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace TodoApp.UI.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public TodoActions.TodoActionsClient Client { get; set; }

        public IEnumerable<TodoItem> Items { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await Client.GetUncompleteAsync(new GetUncompleteTodosRequest());
            this.Items = response.Items;
        }
    }
}
