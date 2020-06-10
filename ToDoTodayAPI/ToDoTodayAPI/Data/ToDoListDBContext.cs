using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTodayAPI.Models;

namespace ToDoTodayAPI.Data
{
    public class ToDoListDBContext : DbContext
    {
        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().HasData(
               new TaskItem
               {
                   Id = 1,
                   Title = "Clean Gutters",
                   StartTime = DateTime.Now,
                   DueTime = DateTime.Now.AddDays(7),
                   Assignee = "Matthew",
                   Description = "Get up on that ladder and clean out those filthy gutters!",
                   EstimatedTimeToComplete = "2 hours",
                   DifficultyRating = 4,
               },
               new TaskItem
               {
                   Id = 2,
                   Title = "Pot Plants",
                   StartTime = DateTime.Now,
                   DueTime = DateTime.Now.AddDays(7),
                   Assignee = "Matthew",
                   Description = "Your plants are rootbound-- fix it!",
                   EstimatedTimeToComplete = "2 hours",
                   DifficultyRating = 2,
               },
               new TaskItem
               {
                   Id = 3,
                   Title = "Build the Fence",
                   StartTime = DateTime.Now,
                   DueTime = DateTime.Now.AddDays(7),
                   Assignee = "Jessie",
                   Description = "The hard part is done. Now we just have to build and hang the panels.",
                   EstimatedTimeToComplete = "2 hours",
                   DifficultyRating = 3,
               }
               );
        }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
