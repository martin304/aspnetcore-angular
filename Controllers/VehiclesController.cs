using System;
using System.Threading.Tasks;
using angular2.Controllers.Resources;
using angular2.Models;
using angular2.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]VehicleResource vehicleResource)
        {
            var vehicle=mapper.Map<VehicleResource,Vehicle>(vehicleResource);
            vehicle.LastUpdate=DateTime.Now;
            context.Vehicles.Add(vehicle);
          await  context.SaveChangesAsync();
          var result=mapper.Map<Vehicle,VehicleResource>(vehicle);
            return Ok(result);
        }
    }
}