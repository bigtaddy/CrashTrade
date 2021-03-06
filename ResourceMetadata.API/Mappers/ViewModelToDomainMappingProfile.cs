﻿using AutoMapper;
using ResourceMetadata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResourceMetadata.API.ViewModels;

namespace ResourceMetadata.API.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        protected override void Configure()
        {
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>();
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>().ForMember(user => user.UserName, vm => vm.MapFrom(rm => rm.Email));
            Mapper.CreateMap<ManufactureViewModel, Manufacture>();
            Mapper.CreateMap<CarModelViewModel, CarModel>().ForMember(carModel => carModel.Manufacture, vm => vm.Ignore());
            Mapper.CreateMap<AdvertViewModel, Advert>().ForMember(advertModel => advertModel.ImageInfos, vm =>vm.Ignore());

            Mapper.CreateMap<SparePartAdvertViewModel, Advert>().ForMember(advertModel => advertModel.ImageInfos, vm => vm.Ignore());
        }
    }
}