namespace TodoAppWebApi.DTOS.Todo
{
    public class UpdateTodoRequestDTO
    {
      
        public string Title { get; set; }
        public bool IsCompleted { get; set; } = false;  

    }
}
