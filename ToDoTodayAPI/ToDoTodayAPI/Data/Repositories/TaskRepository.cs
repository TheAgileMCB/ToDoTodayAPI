using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoTodayAPI.Models;
using ToDoTodayAPI.Models.Api;
using ToDoTodayAPI.Models.Identity;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ToDoTodayAPI.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private ToDoListDBContext _context;
        private readonly UserManager<ToDoUser> userManager;

        public TaskRepository(ToDoListDBContext context, UserManager<ToDoUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public async Task AddTask(TaskItem task)
        {
            _context.Entry(task).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            _context.Entry(task).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public async Task<TaskItem> EditTask(int id, TaskItem task)
        {
            if (task.Id == id)
            {
                _context.Entry(task).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return task;
        }

        public async Task<List<TaskDTO>> GetAllMyTasks(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            return await _context.TaskItems
                .Where(t => t.CreatedByUserId != null && t.CreatedByUserId == userId)
                .Select(task => new TaskDTO {
                    Id = task.Id,
                    Title = task.Title,
                    StartTime = task.StartTime,
                    DueTime = task.DueTime,
                    Assignee = task.Assignee,
                    Description = task.Description,
                    EstimatedTimeToComplete = task.EstimatedTimeToComplete,
                    DifficultyRating = task.DifficultyRating,
                    CreatedBy = user == null ? null : $"{ user.FirstName} { user.LastName}",
                })
                .ToListAsync();
        }

        public Task<List<TaskDTO>> GetAllTasks()
        {
            //var tasks = await _context.TaskItems;
            //return tasks.ToListAsync();

            return default;
        }

        public async Task<TaskDTO> GetOneTask(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return null;

            var user = await userManager.FindByIdAsync(task.CreatedByUserId);

            return new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                StartTime = task.StartTime,
                DueTime = task.DueTime,
                Assignee = task.Assignee,
                Description = task.Description,
                EstimatedTimeToComplete = task.EstimatedTimeToComplete,
                DifficultyRating = task.DifficultyRating,
                CreatedBy = user == null ? null : $"{ user.FirstName} { user.LastName}",
            };
        }
    }
}