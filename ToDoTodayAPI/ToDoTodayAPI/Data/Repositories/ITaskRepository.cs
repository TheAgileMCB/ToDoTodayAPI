using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTodayAPI.Models.Api;

namespace ToDoTodayAPI.Data.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskDTO>> GetAllTasks();

        Task<TaskDTO> GetOneTask(int Id);

        Task<bool> EditTask(int Id, Task task);

        Task<Task> AddTask(Task task);

        Task<Task> DeleteTask(int Id);
    }
}
