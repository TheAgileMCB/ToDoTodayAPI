using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTodayAPI.Models.Api
{
    public class ToDoUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EyeColor { get; set; }
        public string FavoriteFood { get; set; }

        public DateTime? Birthday { get; set; }
    }
}
