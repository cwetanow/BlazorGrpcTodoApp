//using System;
//using System.Threading.Tasks;
//using Grpc.Core;
//using Microsoft.AspNetCore.Components;

//namespace TodoApp.UI.Pages
//{
//    public partial class Index : ComponentBase
//    {
//        private string Message { get; set; } = "Initial";

//        [Inject]
//        public GreeterService.GreeterServiceClient Client { get; set; }

//        public async Task OnInputValueChange(string newValue)
//        {
//            try
//            {
//                var response = await Client.SayHelloAsync(new HelloRequest { Name = newValue });
//                this.Message = response.Message;
//            }
//            catch (RpcException e)
//            {
//                Console.WriteLine(e);
//            }

//        }
//    }
//}
