using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTodayAPI.Models.Identity
{
    public class RegisterData
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string EyeColor { get; set; }

        public string FavoriteFood { get; set; }

        public DateTime? Birthday { get; set; }
    }
}
