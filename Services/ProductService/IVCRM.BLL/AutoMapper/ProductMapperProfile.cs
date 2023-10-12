using AutoMapper;
using IVCRM.BLL.Models.Products;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.AutoMapper;

public partial class AutoMapperProfile : Profile
{
    public void CreateProductMapperProfile()
    {
        CreateMap<BaseProduct, Product>().ReverseMap();
    }
}