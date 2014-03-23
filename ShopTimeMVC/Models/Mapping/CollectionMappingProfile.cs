using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC.Models.Mapping
{
    public class CollectionMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "CollectionMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Collection, CollectionModel>()
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.CustomFields, opt => opt.Ignore());



            Mapper.CreateMap<CollectionModel, Collection>()
                .ForMember(dest => dest.TagsInDB, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.StoreId, opt => opt.Ignore());



        }
    }
}