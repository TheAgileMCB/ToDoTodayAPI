using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoTodayAPI.Data.Repositories;
using ToDoTodayAPI.Models.Api;

namespace ToDoTodayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITaskRepository _tasks;

        public object ClaimType { get; private set; }

        public TasksController(ITaskRepository tasks)
        {
            _tasks = tasks;
        }

        [HttpGet]
        public async Task<List<TaskDTO>> Get()
        {
            return await _tasks.GetAllTasks();
        }

        [Authorize]
        [HttpGet ("myTasks")]
        public async Task<List<TaskDTO>> GetMyTasks()
        {
            return await _tasks.GetAllMyTasks(GetUserId());
        }

        [HttpGet("{id}")]
        public async Task<TaskDTO> Get(int id)
        {
            return await _tasks.GetOneTask(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Task task)
        {
            task.CreatedByUserId = GetUserId();

            await _tasks.AddTask(task);

            return Ok("Complete!");
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _tasks.DeleteTask(id);
        }

        private string GetUserId()
        {
            return ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
