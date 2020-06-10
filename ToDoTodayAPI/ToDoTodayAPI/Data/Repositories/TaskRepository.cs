using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoTodayAPI.Models.Api;
using Task = ToDoTodayAPI.Models.Task;

namespace ToDoTodayAPI.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public Task<Task> AddTask(Task task)
        {
            throw new NotImplementedException();
        }

        public Task<Task> DeleteTask(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditTask(int Id, Task task)
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