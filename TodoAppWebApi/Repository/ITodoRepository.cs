using TodoAppWebApi.Models;

namespace TodoAppWebApi.Repository
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(int id);
        Task<Todo> CreateAsync(Todo item);
        Task<Todo> UpdateAsync(int id , Todo item);
        Task<Todo> DeleteAsync(int id); 
        Task<bool> AnyAsync(int id);
    }
}
