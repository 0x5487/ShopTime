using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data.Mapping
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
            Mapper.CreateMap<Product, ProductEntity>()
                .ForMember(dest => dest.StoreId, opt => opt.Ignore());


            Mapper.CreateMap<ProductEntity, Product>();

        }
    }
}
