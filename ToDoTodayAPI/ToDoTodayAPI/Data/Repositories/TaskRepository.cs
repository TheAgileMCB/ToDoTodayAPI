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

        public async System.Threading.Tasks.Task AddTask(TaskItem task)
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

        public Task<bool> EditTask(int Id, TaskItem task)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskDTO>> GetAllMyTasks(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskDTO>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Task<TaskDTO> GetOneTask(int Id)
        {
            throw new NotImplementedException();
        }
    }
}