using Microsoft.EntityFrameworkCore;
using TodoAppWebApi.Data;
using TodoAppWebApi.Models;

namespace TodoAppWebApi.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;
        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       
        
        public Task<bool> AnyAsync(int id)
        {
            return _context.todos.AnyAsync(x=>x.Id == id);
        }

        public async Task<Todo> CreateAsync(Todo item)
        {
           await _context.todos.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
            
              
            
        }

        public async Task<Todo> DeleteAsync(int id)
        {
           var todo = await _context .todos.FindAsync(id);
            if (todo == null) 
            {
           return null;
            }
             _context.todos.Remove(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public Task<List<Todo>> GetAllAsync()
        {
           return _context.todos.ToListAsync(); 
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _context.todos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Todo?> UpdateAsync(int id, Todo item)
        {
            var todosko = await _context.todos.FindAsync(id);
            if(todosko == null)
            {
                return null;

            }
          todosko.Title = item.Title;
        todosko.IsCompleted = item.IsCompleted;
            await _context .SaveChangesAsync();
            return todosko;
        }
    }
}
