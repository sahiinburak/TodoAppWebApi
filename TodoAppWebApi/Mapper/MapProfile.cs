using TodoAppWebApi.DTOS.Todo;
using TodoAppWebApi.Models;

namespace TodoAppWebApi.Mapper
{
    public static class MapProfile
    {
        public static TodoDTO toTodoDto(this Todo todo)
        {
            return new TodoDTO
            {
                Id = todo.Id,
                Title = todo.Title,
                IsCompleted = todo.IsCompleted,

            };
        }

        public static Todo ToTodoFromCreateDto(this CreateTodoRequestDTO todoDto)
        {
            return new Todo
            {
                Title = todoDto.Title,
                IsCompleted = todoDto.IsCompleted,
                CreatedTıme = todoDto.CreatedTıme
            };
        }

        public static Todo ToTodoFromUpdateDto(this UpdateTodoRequestDTO todoDto)
        {
            return new Todo
            {
                Title = todoDto.Title,
                IsCompleted = todoDto.IsCompleted,
            };
        }
    }
}
