using AutoMapper;
using ResourceMetadata.Models;
using ResourceMetadata.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceMetadata.API.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappingProfile";
            }
        }


        protected override void Configure()
        {
            Mapper.CreateMap<Resource, ResourceViewModel>();
            Mapper.CreateMap<Location, LocationViewModel>();
            Mapper.CreateMap<ResourceActivity,ResourceActivityViewModel>()
                .ForMember(vm => vm.ActivityDateString, dm=> dm.MapFrom(dModel => dModel.ActivityDate.ToLongDateString()));
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            Mapper.CreateMap<Manufacture, ManufactureViewModel>();
            Mapper.CreateMap<CarModel, CarModelViewModel>();
            Mapper.CreateMap<Advert, AdvertViewModel>();

        }
    }
}