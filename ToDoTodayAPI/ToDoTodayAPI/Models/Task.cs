using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTodayAPI.Models
{
    public class Task
    {
        [Required]
        public string Title { get; set; }
        public string StartTime { get; set; }

        public string DueTime { get; set; }

        public string Description { get; set; }
        public string EstimatedTimeToComplete { get; set; }
    }
}
