using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTodayAPI.Data
{
    public class UserDbContext : IdentityDbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
