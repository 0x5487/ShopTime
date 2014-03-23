using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC.Models.Mapping
{
    public class CustomFieldMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "CustomFieldMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CustomField, CustomFieldModel>();

            Mapper.CreateMap<CustomFieldModel, CustomField>()
                .ForMember(dest => dest.Type, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.ParentId, opt => opt.Ignore())
                .ForMember(dest => dest.StoreId, opt => opt.Ignore());


        }
    }
}