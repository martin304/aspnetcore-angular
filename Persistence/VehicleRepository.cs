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
        public async Task<Vehicle> GetVehicle(int id)
        {
            var vehicle = await context.Vehicles
            .Include(v => v.Features)
            .ThenInclude(vf => vf.Feature)
            .Include(v => v.Model)
            .ThenInclude(m => m.Make)
            .SingleOrDefaultAsync(v => v.Id == id);
            return vehicle;
        }
    }

    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id);
    }
}