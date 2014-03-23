using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JasonSoft.ShopTimeMVC.Models.Mapping;

namespace JasonSoft.ShopTimeMVC
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CollectionMappingProfile>();
                x.AddProfile<CustomFieldMappingProfile>();
                x.AddProfile<ImageMappingProfile>();
                x.AddProfile<ProductMappingProfile>();
                x.AddProfile<VariationMappingProfile>();
            });
      
            Mapper.Configuration.AllowNullCollections = true;

        }
    }
}