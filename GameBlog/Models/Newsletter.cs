using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.Models
{
    [Index("Email", IsUnique = true)]
    public class Newsletter
    {
        public int Id { get; set; }
        
        [Required]
        
        public string Email { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}