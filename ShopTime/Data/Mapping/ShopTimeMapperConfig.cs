using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace JasonSoft.ShopTime.Data.Mapping
{
    public class ShopTimeMapperConfig
    {

        public static void Configure()
        {
            

            Mapper.Initialize(x =>
            {
                x.AddProfile<CollectionMappingProfile>();
                x.AddProfile<ImageMappingProfile>();
                x.AddProfile<ProductMappingProfile>();
            });

            Mapper.Configuration.AllowNullCollections = true;

        }

    }
}
