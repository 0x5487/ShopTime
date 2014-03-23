using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC.Models.Mapping
{
    public class ImageMappingProfile: Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ImageMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Image, ImageModel>()
                .ForMember(dest => dest.CustomFields, opt => opt.Ignore());


            Mapper.CreateMap<ImageModel, Image>()
                .ForMember(dest => dest.CustomFields, opt => opt.Ignore())
                .ForMember(dest => dest.FileName, opt => opt.Ignore())
                .ForMember(dest => dest.StoreId, opt => opt.Ignore());

        }
    }
}