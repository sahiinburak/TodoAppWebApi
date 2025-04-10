using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAppWebApi.DTOS.Todo;
using TodoAppWebApi.Mapper;
using TodoAppWebApi.Repository;

namespace TodoAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var todos = await _todoRepository.GetAllAsync();
            return Ok(todos.Select(x => x.toTodoDto()));
        }
        [HttpGet("{id}")]
      public async Task<IActionResult> GetByIdAsync(int id)
        {
           var todo = await _todoRepository.GetByIdAsync(id);   
            if(todo == null)
            {
                return NotFound();
            }
        return Ok(todo.toTodoDto());    
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoRequestDTO todoRequestDTO)
        {
            var todo = todoRequestDTO.ToTodoFromCreateDto();
            await _todoRepository.CreateAsync(todo);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = todo.Id }, todo.toTodoDto());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoRequestDTO todoDto)
        {
            var todo = await _todoRepository.UpdateAsync(id, todoDto.ToTodoFromUpdateDto());
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo.toTodoDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var todo = await _todoRepository.DeleteAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}

