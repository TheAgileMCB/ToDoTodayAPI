using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTodayAPI.Models.Api;
using ToDoTodayAPI.Models;
using Task = ToDoTodayAPI.Models.Task;

namespace ToDoTodayAPI.Data.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskDTO>> GetAllTasks();

        Task<List<TaskDTO>> GetAllMyTasks(string id);

        Task<TaskDTO> GetOneTask(int Id);

        Task<bool> EditTask(int Id, Task task);

        Task<Task> AddTask(Task task);

        Task<Task> DeleteTask(int Id);
    }
}
