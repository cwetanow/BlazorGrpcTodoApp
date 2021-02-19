using System.Threading.Tasks;
using Grpc.Core;

namespace TodoApp.Backend.Services
{
    public class GreetService : GreeterService.GreeterServiceBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var result = new HelloReply
            {
                Message = $"Hello {request.Name}"
            };

            return Task.FromResult(result);
        }
    }
}
