namespace TodoAppWebApi.DTOS.Todo
{
    public class CreateTodoRequestDTO
    {
        public string Title { get; set; }   
        public bool IsCompleted = false;
        public DateTime CreatedTıme {  get; set; }  

    }
}
