using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTodayAPI.Data
{
    public class ToDoListDBContext : DbContext
    {
        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options) : base(options)
        {

        }

        public DbSet<Task> Task { get; set; }
    }
}
