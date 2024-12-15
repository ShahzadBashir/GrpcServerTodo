using Grpc.Core;

namespace GrpcServerTodo.Services
{
    public class TodoService : GrpcServerTodo.TodoService.TodoServiceBase
    {
        private static List<Todo> _todoList = new List<Todo>();

        public override Task<TodoResponse> AddTodo(TodoRequest request, ServerCallContext context)
        {
            var newTodo = new Todo
            {
                Id = (_todoList.Count + 1).ToString(),
                Title = request.Title,
                Completed = false
            };

            _todoList.Add(newTodo);

            return Task.FromResult(new TodoResponse
            {
                Status = "Todo Added",
                Todo = newTodo
            });
        }

        public override Task<TodoResponse> RemoveTodo(RemoveTodoRequest request, ServerCallContext context)
        {
            Todo? todo = _todoList.Find(x => x.Id == request.Id);

            if(todo != null)
            {
                _todoList.Remove(todo);
            }

            return Task.FromResult(new TodoResponse
            {
                Status = "Todo Removed",
                Todo = todo
            });
        }

        public override Task<TodoResponse> CompleteTodo(CompleteTodoRequest request, ServerCallContext context)
        {
            Todo? todo = _todoList.Find(x => x.Id == request.Id);

            if (todo != null)
            {
                todo.Completed = true;
            }

            return Task.FromResult(new TodoResponse
            {
                Status = "Todo Completed",
                Todo = todo
            });
        }

        public override async Task TodoUpdates(
            IAsyncStreamReader<TodoRequest> requestStream, 
            IServerStreamWriter<TodoResponse> responseStream, 
            ServerCallContext context)
        {
            await foreach (var request in requestStream.ReadAllAsync())
            {
                var todo = new Todo
                {
                    Id = (_todoList.Count + 1).ToString(),
                    Title = request.Title,
                    Completed = false
                };

                _todoList.Add(todo);

                await responseStream.WriteAsync(new TodoResponse
                {
                    Status = "Todo Added",
                    Todo = todo
                });

                // Stream current todos periodically
                await Task.Delay(5000); // Simulate real-time updates
                foreach (var _todo in _todoList)
                {
                    await responseStream.WriteAsync(new TodoResponse
                    {
                        Status = "Current Todo List",
                        Todo = _todo
                    });
                }
            }
        }
    }
}
