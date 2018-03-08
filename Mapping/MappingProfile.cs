using System.Collections.Generic;
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
              .ForMember(v=>v.Id,opt=>opt.Ignore())
              .ForMember(v=>v.contactName,opt =>opt.MapFrom(vr=>vr.Contact.Name))
              .ForMember(v=>v.contactEmail,opt=>opt.MapFrom(vr=>vr.Contact.Email))
              .ForMember(v=>v.contactPhone,opt=>opt.MapFrom(vr=>vr.Contact.Phone))
              .ForMember(v=>v.Features,opt=>opt.Ignore())
              .AfterMap((vr,v)=>{
                  //remove unselect features
                  var removedFeatures=new List<VehicleFeature>();
                  foreach(var f in v.Features){
                      if(!vr.Features.Contains(f.FeatureId)){
                          removedFeatures.Add(f);
                      }
                  }
                  foreach(var f in removedFeatures){
                      v.Features.Remove(f);
                  }
                  //add new features
                  foreach(var id in vr.Features){
                      if(!v.Features.Any(vf=>vf.FeatureId==id)){
                          v.Features.Add(new VehicleFeature{FeatureId=id});
                      }
                  }
              });
        }
    }
}