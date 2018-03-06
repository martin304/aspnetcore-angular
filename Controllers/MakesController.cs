using System.Collections.Generic;
using System.Threading.Tasks;
using angular2.Controllers.Resources;
using angular2.Models;
using angular2.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace angular2.Controllers
{
    public class MakesController : Controller
    {
        private readonly NgDbContext Context;
        private readonly IMapper mapper;
        public MakesController(NgDbContext Context, IMapper mapper)
        {
            this.mapper = mapper;
            this.Context = Context;

        }
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
           var makes =await Context.Makes.Include(m => m.Models).ToListAsync();
           return mapper.Map<List<Make>,List<MakeResource>>(makes);
        }
    }
}