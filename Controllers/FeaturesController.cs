using System.Collections.Generic;
using angular2.Models;
using angular2.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace angular2.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly NgDbContext context;
        public FeaturesController(NgDbContext context)
        {
            this.context = context;

        }
        [HttpGet("/api/features")]
        public IEnumerable<Feature> GetFeatures()
        {
            return context.Features;
        }
    }
}