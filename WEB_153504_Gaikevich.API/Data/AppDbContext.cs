using System;
using Microsoft.EntityFrameworkCore;
using WEB_153504_Gaikevich.Domain.Entities;

namespace WEB_153504_Gaikevich.API.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AutoPart> AutoPart { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
