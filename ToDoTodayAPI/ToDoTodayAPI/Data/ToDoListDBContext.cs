using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTodayAPI.Data
{
    public class ToDoListDBContext : DbContext
    {
        public ToDoListDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
