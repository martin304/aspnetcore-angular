using System;
using Microsoft.EntityFrameworkCore;

namespace angular2.Persistence
{
    public class NgDbContext:DbContext
    {
        public NgDbContext(DbContextOptions<NgDbContext> options)
        :base(options)
        {
            
        }
    }
}