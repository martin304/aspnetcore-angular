using System.Linq;
using angular2.Controllers.Resources;
using angular2.Models;
using AutoMapper;

namespace angular2.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<Make,MakeResource>();
            CreateMap<Model,ModelResource>();
            //API Resource to Domain
            CreateMap<VehicleResource,Vehicle>()
              .ForMember(v=>v.contactName,opt =>opt.MapFrom(vr=>vr.Contact.Name))
              .ForMember(v=>v.contactEmail,opt=>opt.MapFrom(vr=>vr.Contact.Email))
              .ForMember(v=>v.contactPhone,opt=>opt.MapFrom(vr=>vr.Contact.Phone))
              .ForMember(v=>v.Features,opt=>opt.MapFrom(vr=>vr.Features.Select(id=>new VehicleFeature{FeatureId=id})));
        }
    }
}