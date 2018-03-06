using System;
using angular2.Models;
using Microsoft.EntityFrameworkCore;

namespace angular2.Persistence
{
    public class NgDbContext:DbContext
    {
        public NgDbContext(DbContextOptions<NgDbContext> options)
        :base(options)
        {
            
        }
        public DbSet<Make> Makes{get;set;}
        public DbSet<Feature> Features{get;set;}
    }
}