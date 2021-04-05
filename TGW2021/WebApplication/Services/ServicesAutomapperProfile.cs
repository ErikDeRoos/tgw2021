using AutoMapper;
using WebApplication.Data.DataModels.Product;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class ServicesAutomapperProfile : Profile
    {
        public ServicesAutomapperProfile()
        {
            CreateMap<ProductCategoryProjection, ProductBrowserCategoryViewModel>();
            CreateMap<ProductProjection, ProductBrowserItemViewModel>();

        }
    }
}
