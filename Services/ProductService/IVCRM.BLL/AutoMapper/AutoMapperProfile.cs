using AutoMapper;

namespace IVCRM.BLL.AutoMapper;

public partial class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateProductMapperProfile();
    }
}