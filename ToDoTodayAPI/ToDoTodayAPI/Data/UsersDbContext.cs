using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTodayAPI.Models;

namespace ToDoTodayAPI.Data
{
    public class UsersDbContext : IdentityDbContext<ToDoUser>
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var administrator = new IdentityRole
            {
                Id = "administrator",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "a2fd5bd0-76f0-411c-91b1-fec407fab810"
            };
            //var moderator = new IdentityRole
            //{
            //    Id = "moderator",
            //    Name = "Moderator",
            //    NormalizedName = "MODERATOR",
            //};
            var editor = new IdentityRole
            {
                Id = "editor",
                Name = "Editor",
                NormalizedName = "EDITOR",
                ConcurrencyStamp = "a063e65e-5b01-4315-a84d-362947875ca9"
            };
            builder.Entity<IdentityRole>()
                .HasData(administrator, editor);

            builder.Entity<IdentityRoleClaim<string>>()
                .HasData(
                    new IdentityRoleClaim<string> { Id = 1, RoleId = "administrator", ClaimType = "Permissions", ClaimValue = "delete" },
                    new IdentityRoleClaim<string> { Id = 2, RoleId = "administrator", ClaimType = "Permissions", ClaimValue = "create" },
                    new IdentityRoleClaim<string> { Id = 3, RoleId = "administrator", ClaimType = "Permissions", ClaimValue = "update" },
                    new IdentityRoleClaim<string> { Id = 4, RoleId = "editor", ClaimType = "Permissions", ClaimValue = "update" }
                );
        }
    }
}
