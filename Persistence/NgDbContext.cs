using System;
using angular2.Models;
using Microsoft.EntityFrameworkCore;

namespace angular2.Persistence
{
    public class NgDbContext:DbContext
    {
        public DbSet<Make> Makes{get;set;}
        public DbSet<Feature> Features{get;set;}
        public NgDbContext(DbContextOptions<NgDbContext> options)
        :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
          modelBuilder.Entity<VehicleFeature>().HasKey(vf=> 
             new {vf.VehicleId,vf.FeatureId});
        }
    }
}