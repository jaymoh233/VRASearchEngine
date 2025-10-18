using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VRASearchEngine.Models
{
    public class AdminModel
    {
        [Key]
        public int AdminId { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // You’ll later replace this with ASP.NET Identity

        public string Role { get; set; } = "Admin";

        // Optional fields
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}