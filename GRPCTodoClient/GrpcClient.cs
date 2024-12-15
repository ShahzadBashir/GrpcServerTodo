using Grpc.Core;
using Grpc.Net.Client;
using GrpcServerTodo;

namespace GRPCTodoClient
{
    public class GrpcClient
    {
        private readonly TodoService.TodoServiceClient _client;
        public GrpcClient() 
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7098");

            _client = new TodoService.TodoServiceClient(channel);
        }

        public async Task AddTodoAsync(string title)
        {
            var request = new TodoRequest { Title = title };
            var response = await _client.AddTodoAsync(request);
            
            Console.WriteLine($"Status: {response.Status}");
        }

        public async Task StreamTodoUpdatesAsync()
        {
            using var call = _client.TodoUpdates();

            await call.RequestStream.WriteAsync(new TodoRequest { Title = "Sample Todo" });

            await foreach (var response in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine($"Status: {response.Status}, Todo: {response.Todo.Title}");
            }
        }
    }
}
