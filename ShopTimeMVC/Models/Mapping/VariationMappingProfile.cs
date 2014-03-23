using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC.Models.Mapping
{
    public class VariationMappingProfile : Profile
    {

        public override string ProfileName
        {
            get
            {
                return "VariationMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Variant, VariationModel>()
                .ForMember(dest => dest.Options, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.CustomFields, opt => opt.Ignore());


            Mapper.CreateMap<VariationModel, Variant>()
                .ForMember(dest => dest.VariantOptions, opt => opt.Ignore())
                .ForMember(dest => dest.ProductType, opt => opt.Ignore())
                .ForMember(dest => dest.ParentProduct, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.ProductStatus, opt => opt.Ignore())
                .ForMember(dest => dest.CustomFields, opt => opt.Ignore())
                .ForMember(dest => dest.ParentProductId, opt => opt.Ignore())
                .ForMember(dest => dest.StoreId, opt => opt.Ignore());

        }
    }
}