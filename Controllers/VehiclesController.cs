using System;
using System.Threading.Tasks;
using angular2.Controllers.Resources;
using angular2.Models;
using angular2.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace angular2.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly NgDbContext context;
        private readonly IMapper mapper;
        public VehiclesController(NgDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var  vehicle=   await  context.Vehicles
            .Include(v=>v.Features)
            .ThenInclude(vf=>vf.Feature)
            .Include(v=>v.Model)
            .ThenInclude(m=>m.Make)
            .SingleOrDefaultAsync(v=>v.Id==id);
            if(vehicle==null)
            return NotFound();
          var vehicleResource=mapper.Map<Vehicle,VehicleResource>(vehicle);
            return Ok(vehicleResource);
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
            await  context.Models.Include(m=>m.Make).SingleOrDefaultAsync(m=>m.Id==vehicle.ModelId);
             vehicle=   await  context.Vehicles
            .Include(v=>v.Features)
            .ThenInclude(vf=>vf.Feature)
            .Include(v=>v.Model)
            .ThenInclude(m=>m.Make)
            .SingleOrDefaultAsync(v=>v.Id==vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           var vehicle=   await  context.Vehicles
            .Include(v=>v.Features)
            .ThenInclude(vf=>vf.Feature)
            .Include(v=>v.Model)
            .ThenInclude(m=>m.Make)
            .SingleOrDefaultAsync(v=>v.Id==id);
             if (vehicle == null)
                return NotFound();
            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await context.SaveChangesAsync();
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await context.Vehicles.FindAsync(id);
            if (vehicle == null)
                return NotFound();
            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();
            return Ok(id);
        }
    }
}