﻿namespace TodoAppWebApi.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }   
        public string Title { get; set; } = string.Empty;   
        public bool IsCompleted { get; set; }   
        public DateTime CreatedTıme { get; set; }   
        public AppUser AppUser { get; set; }    

    }
}
