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
            CreateMap<Vehicle,VehicleResource>()
               .ForMember(vr=>vr.Contact,opt =>opt.MapFrom(v=>new ContactResource{Name=v.contactName,Email=v.contactEmail,Phone=v.contactPhone}))
               .ForMember(vr=>vr.Features,opt=>opt.MapFrom(v=>v.Features.Select(vf=>vf.FeatureId)));
            //API Resource to Domain
            CreateMap<VehicleResource,Vehicle>()
              .ForMember(v=>v.contactName,opt =>opt.MapFrom(vr=>vr.Contact.Name))
              .ForMember(v=>v.contactEmail,opt=>opt.MapFrom(vr=>vr.Contact.Email))
              .ForMember(v=>v.contactPhone,opt=>opt.MapFrom(vr=>vr.Contact.Phone))
              .ForMember(v=>v.Features,opt=>opt.MapFrom(vr=>vr.Features.Select(id=>new VehicleFeature{FeatureId=id})));
        }
    }
}