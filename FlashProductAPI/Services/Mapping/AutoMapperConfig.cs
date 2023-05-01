using AutoMapper;
using FlashProductAPI_7.Db.DbModels;
using FlashProductAPI_7.Services.ServicesModel;

namespace FlashProductAPI.Services.Mapping
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CustomField, CustomFieldDTO>().ReverseMap();
            CreateMap<CustomFieldValueWrapper, CustomFieldValueWrapperDTO>().ReverseMap();
        }
    }
}
