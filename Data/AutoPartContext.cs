using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEB_153504_Gaikevich.Domain.Entities;

    public class AutoPartContext : DbContext
    {
        public AutoPartContext (DbContextOptions<AutoPartContext> options)
            : base(options)
        {
        }

        public DbSet<WEB_153504_Gaikevich.Domain.Entities.AutoPart> AutoPart { get; set; } = default!;
    }
