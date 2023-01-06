using BlazorApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlazorApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
    }
}
