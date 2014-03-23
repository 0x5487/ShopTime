using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC.Models.Mapping
{
    public class ProductMappingProfile: Profile
    {

        public override string ProfileName
        {
            get
            {
                return "ProductMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.OptionListId, opt => opt.Ignore())
                .ForMember(dest => dest.Variations, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.CustomFields, opt => opt.Ignore());


            Mapper.CreateMap<ProductModel, Product>()
                .ForMember(dest => dest.ProductOptions, opt => opt.Ignore())
                .ForMember(dest => dest.ProductType, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.Variations, opt => opt.Ignore())
                .ForMember(dest => dest.ProductStatus, opt => opt.Ignore())
                .ForMember(dest => dest.CustomFields, opt => opt.Ignore())
                .ForMember(dest => dest.StoreId, opt => opt.Ignore());

        }
    }
}