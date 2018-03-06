using System.Collections.Generic;
using System.Threading.Tasks;
using angular2.Models;
using angular2.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace angular2.Controllers
{
    public class MakesController : Controller
    {
        private readonly NgDbContext Context;
        public MakesController(NgDbContext Context)
        {
            this.Context = Context;

        }
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<Make>> GetMakes()
        {
            return await  Context.Makes.Include(m=>m.Models).ToListAsync();
        }
    }
}