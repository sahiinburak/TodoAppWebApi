using Microsoft.AspNetCore.Identity;

namespace TodoAppWebApi.Models
{
    public class AppUser : IdentityUser
    {
       
        public ICollection<Todo> Todos { get; set; } = new List<Todo>();    
    }
}
