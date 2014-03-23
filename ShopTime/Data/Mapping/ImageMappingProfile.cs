using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JasonSoft.ShopTime.Data.Table;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data.Mapping
{
    public class ImageMappingProfile : Profile
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
            Mapper.CreateMap<Image, ImageEntity>();

            Mapper.CreateMap<ImageEntity, Image>()
                .ForMember(dest => dest.Url, opt => opt.Ignore())
                .ForMember(dest => dest.Attachment, opt => opt.Ignore());
        }
    }
}
