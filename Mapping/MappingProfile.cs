using angular2.Controllers.Resources;
using angular2.Models;
using AutoMapper;

namespace angular2.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Make,MakeResource>();
            CreateMap<Model,ModelResource>();
        }
    }
}