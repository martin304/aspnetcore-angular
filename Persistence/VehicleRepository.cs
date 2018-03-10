using System.Threading.Tasks;
using angular2.Models;
using Microsoft.EntityFrameworkCore;

namespace angular2.Persistence
{
    public class VehicleRepository:IVehicleRepository
    {
        private readonly NgDbContext context;
        public VehicleRepository(NgDbContext context)
        {
            this.context = context;

        }

        public async Task<Vehicle> GetVehicle(int id,bool includeRelated=true)
        {
            if(includeRelated!=false)
            return await context.Vehicles.FindAsync(id);
            
            var vehicle = await context.Vehicles
            .Include(v => v.Features)
            .ThenInclude(vf => vf.Feature)
            .Include(v => v.Model)
            .ThenInclude(m => m.Make)
            .SingleOrDefaultAsync(v => v.Id == id);
            return vehicle;
        }
        public void Add(Vehicle vehicle){
            context.Vehicles.Add(vehicle);
        }
         public void Remove(Vehicle vehicle){
            context.Vehicles.Remove(vehicle);
        }
        //  public async Task<Vehicle> GetVehicleWithMake(int id){
        //   return await context.Vehicles.Include(v=>v.Model).SingleOrDefaultAsync(v=>v.Id==id).Include(v=>v.)
        //  }
    }

    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id,bool includeRelated=true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}