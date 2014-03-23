using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data.Mapping
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
            Mapper.CreateMap<Collection, CollectionEntity>()
                .ForMember(dest => dest.StoreId, opt => opt.Ignore());


            Mapper.CreateMap<CollectionEntity, Collection>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.CustomFields, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ForMember(dest => dest.CurrentTags, opt => opt.Ignore());

        }
    }
}
