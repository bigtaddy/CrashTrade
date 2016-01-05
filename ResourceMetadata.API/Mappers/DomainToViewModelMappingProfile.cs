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

        protected override void Configure()
        {
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            Mapper.CreateMap<Manufacture, ManufactureViewModel>();
            Mapper.CreateMap<CarModel, CarModelViewModel>().ForMember(c => c.Manufacture, c=> c.MapFrom((carModel => carModel.Manufacture.Name)));
            Mapper.CreateMap<Advert, AdvertViewModel>();
            Mapper.CreateMap<Advert, LimitedAdvertViewModel>();
            Mapper.CreateMap<ImageInfo, ImageViewModel>();

            Mapper.CreateMap<SparePartAdvert, SparePartAdvertViewModel>();


        }
    }
}