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
            CreateMap<Vehicle,SaveVehicleResource>()
               .ForMember(vr=>vr.Contact,opt =>opt.MapFrom(v=>new ContactResource{Name=v.contactName,Email=v.contactEmail,Phone=v.contactPhone}))
               .ForMember(vr=>vr.Features,opt=>opt.MapFrom(v=>v.Features.Select(vf=>vf.FeatureId)));
             CreateMap<Vehicle,VehicleResource>()
               .ForMember(vr=>vr.Contact,opt =>opt.MapFrom(v=>new ContactResource{Name=v.contactName,Email=v.contactEmail,Phone=v.contactPhone}))
               .ForMember(vr=>vr.Features,opt=>opt.MapFrom(v=>v.Features.Select(vf=>new FeatureResource{Id=vf.Feature.Id,Name=vf.Feature.Name})))
               .ForMember(vr=>vr.Make,opt=>opt.MapFrom(v=>v.Model.Make));
            //API Resource to Domain
            CreateMap<SaveVehicleResource,Vehicle>()
              .ForMember(v=>v.Id,opt=>opt.Ignore())
              .ForMember(v=>v.contactName,opt =>opt.MapFrom(vr=>vr.Contact.Name))
              .ForMember(v=>v.contactEmail,opt=>opt.MapFrom(vr=>vr.Contact.Email))
              .ForMember(v=>v.contactPhone,opt=>opt.MapFrom(vr=>vr.Contact.Phone))
              .ForMember(v=>v.Features,opt=>opt.Ignore())
              .AfterMap((vr,v)=>{
                  //remove unselect features
                 
             var  removedFeatures= v.Features.Where(f=>!vr.Features.Contains(f.FeatureId));
                  foreach(var f in removedFeatures){
                      v.Features.Remove(f);
                  }
                  //add new features
               var addedFeatures=   vr.Features.Where(id=>!v.Features.Any(vf=>vf.FeatureId==id)).Select(id=>new VehicleFeature{FeatureId=id});
                  foreach(var f in addedFeatures){
                          v.Features.Add(f);
                  }
              });
        }
    }
}