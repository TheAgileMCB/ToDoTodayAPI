using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTodayAPI.Models.Api
{
    public class TaskDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTime? StartTime { get; set; }

        public DateTime? DueTime { get; set; }

        public string Assignee { get; set; }

        public string Description { get; set; }

        public string EstimatedTimeToComplete { get; set; }

        public int DifficultyRating { get; set; }

        public string CreatedBy { get; set; }

    }
}
